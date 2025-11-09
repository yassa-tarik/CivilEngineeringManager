using Domain.Abstractions.Works;
using DTO.TreeDTOs;
using DTO.Works.WorkCategories;
using DTO.Works.WorkSpecs;
using DTO.Works.WorkTypes;
using MyApplication.Abstractions;
using MyApplication.Abstractions.Works;
using MyApplication.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApplication.Services.Trees
{
    /// <summary>
    /// A service responsible for retrieving and building a hierarchical tree of WorkCategories, WorkTypes, and WorkSpecs.
    /// </summary>
    public class ProjectTreeService : IProjectTreeService
    {
        private readonly IProjectService _projectService;
        private readonly IWorkCategoryService _workCategoryService;
        private readonly IWorkTypeService _workTypeService;
        private readonly IWorkSpecService _workSpecService;

        public ProjectTreeService(IProjectService projectService, IWorkCategoryRepository workCategoryRepository, IWorkTypeService workTypeService, IWorkCategoryService workCategoryService, IWorkSpecService workSpecService)
        {
            _projectService = projectService;
            _workTypeService = workTypeService;
            _workCategoryService = workCategoryService;
            _workSpecService = workSpecService;
        }

        public async Task<ProjectTreeDTO> GetProjectTreeAsync(int projectID)
        {            
            //TODO: will change later to real project
            var projectMin = _projectService.GetMockProjects().Find(p => p.ID == projectID);
            if (projectMin == null)
                throw new Exception("project not found!");
            var projectTree = new ProjectTreeDTO(projectMin.ID, projectMin.Name);
            //check if projectTree not empty to proceed otherwise stop
            var categoryTrees = await GetWorkCategoryTreeAsync(projectID);
            foreach (var item in categoryTrees)
            {
                projectTree.WorkCategories.Add(item);
            }
            return projectTree;
        }

        /// <summary>
        /// Builds the complete hierarchical tree for all work categories.
        /// </summary>
        /// <returns>A collection of WorkCategoryTreeDTO objects representing the full hierarchy.</returns>
        public async Task<IEnumerable<WorkCategoryTreeDTO>> GetWorkCategoryTreeAsync(int projectID)
        {
            //TODO: will fetch only one list that has the whole Tree for specific Project
            // Step 1: Fetch all data from the database
            var allCategories = await _workCategoryService.GetAllForProjectAsync(projectID);
            //TODO: will return empty initialized Tree
            if (allCategories.Count <= 0) 
            { 
                return new List<WorkCategoryTreeDTO>();
                //throw new Exception($"No category exists for this project ID{projectID}"); 
            }
            var categoryListIDs = allCategories.Select(c => c.ID).ToList();

            var allWorkTypes = await _workTypeService.GetAllForCategoriesRootsAsync(projectID);
            //TODO: to be continued
            var allWorkSpecsDTO = await _workSpecService.GetAllSpecsForCategoriesAndTypesAsync(projectID);

            // Step 2.0: Group WorkSpecs by WorkCategoryID for efficient lookup
            var workSpecsByWorkCategory = allWorkSpecsDTO.Where(ws => ws.WorkCategory_ID != null).GroupBy(ws => ws.WorkCategory_ID)
                .ToDictionary(g => g.Key, g => g.ToList());

            // Step 2.1: Group WorkSpecs by WorkTypeID for efficient lookup
            var workSpecsByWorkType = allWorkSpecsDTO.Where(ws => ws.WorkType_ID != null).GroupBy(ws => ws.WorkType_ID).ToDictionary(g => g.Key, g => g.ToList());

            // Step 3: Map all WorkTypes to their DTOs and build the hierarchy
            var workTypeMap = allWorkTypes.ToDictionary(
                wt => wt.ID,
                wt => new WorkTypeTreeDTO
                {
                    ID = wt.ID,
                    WorkCategory_ID = wt.WorkCategory_ID,
                    Parent_ID = wt.Parent_ID,
                    Designation = wt.Designation,
                    // Assign WorkSpecs to their DTOs if they exist
                    WorkSpecs = workSpecsByWorkType.ContainsKey(wt.ID)
                        ? workSpecsByWorkType[wt.ID].ToList() : new List<WorkSpecUpdateDTO>()
                });

            // Step 4: Build the parent-child relationships for WorkTypes
            foreach (var workType in workTypeMap.Values)
            {
                if (workType.Parent_ID.HasValue && workTypeMap.ContainsKey(workType.Parent_ID.Value))
                {
                    workTypeMap[workType.Parent_ID.Value].WorkTypes.Add(workType);
                }
            }

            // Step 5: Build the final tree by assigning top-level WorkTypes to Categories
            var categoryTrees = allCategories.Select(c => new WorkCategoryTreeDTO
            {
                ID = c.ID,
                Designation = c.Designation,
                WorkCategoryDesignation_ID = c.WorkCategoryDesignation_ID,
                WorkTypes = workTypeMap.Values.Where(wt => wt.WorkCategory_ID == c.ID && !wt.Parent_ID.HasValue).ToList(),
                WorkSpecs = workSpecsByWorkCategory.ContainsKey(c.ID) ? workSpecsByWorkCategory[c.ID] : new List<WorkSpecUpdateDTO>()
            }).ToList();
            return categoryTrees;
        }

        //TODO: wrap in Transaction
        public async Task<bool> SaveProjectTree(ProjectTreeDTO projectTreeDTO)
        {
            //TODO: put this method into Transaction
            if (projectTreeDTO == null)
            {
                return false;
            }
            if (projectTreeDTO.WorkCategories.Count <= 0)
            {
                return false;
            }
            int categoryID;
            foreach (var category in projectTreeDTO.WorkCategories)
            {

                if (category.ID > 0)
                {
                    WorkCategoryUpdateDTO newCategory = WorkCategoryMapper.TreeDtoToUpdateDTO(category);
                    // Update the category
                    categoryID = await _workCategoryService.UpdateAsync(newCategory);
                }
                else
                {
                    WorkCategoryCreateDTO newCategory = WorkCategoryMapper.TreeDtoToCreateDTO(category);
                    // Add new Category using Category Service and Get the new ID
                    categoryID = await _workCategoryService.AddAsync(newCategory);
                }
                // Save its Children by calling another method recursively
                SaveWorkSpecs(category.WorkSpecs, categoryID, null);
                await SaveWorkTypes(category.WorkTypes, categoryID, null);
            }
            return true;
        }

        private async Task<bool> SaveWorkTypes(ICollection<WorkTypeTreeDTO> workTypes, int? categoryParentID, int? typeParentID)
        {
            try
            {
                int newTypeID;
                foreach (var type in workTypes)
                {

                    if (type.ID > 0)
                    {
                        WorkTypeUpdateDTO newTypeDTO = WorkTypeMapper.TreeDtoToUpdateDTO(type);
                        newTypeID = await _workTypeService.UpdateAsync(newTypeDTO);
                    }
                    else
                    {
                        WorkTypeCreateDTO newTypeCreateDTO = WorkTypeMapper.TreeDtoToCreateDTO(type);
                        if (categoryParentID.HasValue)
                        {
                            newTypeCreateDTO.WorkCategory_ID = categoryParentID.Value;
                            newTypeCreateDTO.Parent_ID = null; //double check
                        }
                        else
                        {
                            newTypeCreateDTO.Parent_ID = typeParentID.Value;
                            newTypeCreateDTO.WorkCategory_ID = null; //double check
                        }
                        newTypeID = await _workTypeService.AddAsync(newTypeCreateDTO);
                    }
                    if (type.WorkSpecs.Count > 0)
                    {
                        SaveWorkSpecs(type.WorkSpecs, null, newTypeID);
                    }
                    if (type.WorkTypes.Count > 0)
                    {
                        await SaveWorkTypes(type.WorkTypes, null, type.ID);
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        private bool SaveWorkSpecs(ICollection<WorkSpecUpdateDTO> workSpecs, int? categoryParentID, int? typeParentID)
        {
            //TODO: make boolean flag later
            try
            {
                foreach (var workSpec in workSpecs)
                {
                    if (workSpec.ID > 0)
                    {
                        _workSpecService.UpdateAsync(workSpec);
                    }
                    else
                    {
                        if (categoryParentID == null)
                        {
                            workSpec.WorkType_ID = typeParentID.Value;
                            workSpec.WorkCategory_ID = null; //double check
                        }
                        else
                        {
                            workSpec.WorkCategory_ID = categoryParentID.Value;
                            workSpec.WorkType_ID = null; //double check
                        }
                        WorkSpecCreateDTO createDTO = WorkSpecMapper.UpdateDtoToCreateDto(workSpec);
                        _workSpecService.AddAsync(createDTO);
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
