using Domain.Abstractions;
using DTO.TreeDTOs;
using DTO.Works.WorkCategories;
using DTO.Works.WorkSpecs;
using DTO.Works.WorkTypes;
using MyApplication.Abstractions;
using MyApplication.Abstractions.Trees;
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
    public class ProjectWorkSpecsTreeService : IProjectWorkSpecsTreeService
    {
        private readonly IProjectWorkDataService _projectWorkDataService;
        private readonly IUnitOfWork _unitOfWork;

        public ProjectWorkSpecsTreeService(IUnitOfWork unitOfWork,
            IProjectWorkDataService projectWorkDataService)
        {
            _unitOfWork = unitOfWork;
            _projectWorkDataService = projectWorkDataService;
        }

        public async Task<ProjectTreeDTO> GetProjectTreeForSpecificationsAsync(int projectID)
        {
            //TODO: will change later to real project
            var allProjectsMin = await _projectWorkDataService.Projects.GetAllMinAsync();
            var projectMin = allProjectsMin.Find(p => p.ID == projectID);
            if (projectMin == null)
                throw new Exception("project not found!");//TODO: will check the default value
            var projectTree = new ProjectTreeDTO(projectMin.ID, projectMin.Name);
            //check if projectTree not empty to proceed otherwise stop
            var categoryTrees = await GetWorkCategoryBranchAsync(projectID);
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
        private async Task<IEnumerable<WorkCategoryTreeDTO>> GetWorkCategoryBranchAsync(int projectID)
        {
            //TODO: will fetch only one list that has the whole Tree for specific Project
            var allCategories = await _projectWorkDataService.Categories.GetAllForProjectAsync(projectID);
            //TODO: will return empty initialized Tree
            if (allCategories.Count <= 0)
            {
                return new List<WorkCategoryTreeDTO>();
                //throw new Exception($"No category exists for this project ID{projectID}"); 
            }
            var categoryListIDs = allCategories.Select(c => c.ID).ToList();

            var allWorkTypes = await _projectWorkDataService.Types.GetAllForCategoriesRootsAsync(projectID);

            var allWorkSpecsDTO = await _projectWorkDataService.Specs.GetAllSpecsForProjectAsync(projectID, isAssigned: false);

            // Step 2.0: Group WorkSpecs by WorkCategoryID for efficient lookup
            var workSpecsByWorkCategory = allWorkSpecsDTO.Where(ws => ws.WorkCategory_ID != null).GroupBy(ws => ws.WorkCategory_ID)
                .ToDictionary(g => g.Key, g => g.ToList());

            // Step 2.1: Group WorkSpecs by WorkTypeID for efficient lookup
            var workSpecsByWorkType = allWorkSpecsDTO.Where(ws => ws.WorkType_ID != null).GroupBy(ws => ws.WorkType_ID).ToDictionary(g => g.Key, g => g.ToList());

            // Step 3: Map all WorkTypes to their Parents(WorkType) and build the hierarchy
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

        //wraped in Transaction
        public async Task<bool> SaveProjectTree(ProjectTreeDTO projectTreeDTO)
        {
            await _unitOfWork.BeginAsync();
            try
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
                int newCategoryID;
                foreach (var category in projectTreeDTO.WorkCategories)
                {
                    if (category.ID > 0)
                    {
                        WorkCategoryUpdateDTO newCategory = WorkCategoryMapper.TreeDtoToUpdateDTO(category);
                        //TODO: add sqlConnection and sqlTransaction
                        // Update the category
                        newCategoryID = await _projectWorkDataService.Categories.UpdateAsyncInTransaction(newCategory, _unitOfWork);
                    }
                    else
                    {
                        WorkCategoryCreateDTO newCategory = WorkCategoryMapper.TreeDtoToCreateDTO(category);
                        // Add new Category using Category Service and Get the new ID
                        newCategoryID = await _projectWorkDataService.Categories.AddAsyncInTransaction(newCategory, _unitOfWork);
                    }
                    // Save its Children by calling another method recursively
                    await SaveWorkSpecs(category.WorkSpecs, newCategoryID, null, _unitOfWork);
                    await SaveWorkTypes(category.WorkTypes, newCategoryID, null, _unitOfWork);
                }
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }

        //wraped in Transaction
        private async Task<bool> SaveWorkTypes(ICollection<WorkTypeTreeDTO> workTypes, int? categoryParentID, int? typeParentID, IUnitOfWork uow)
        {
            try
            {
                int newTypeID;
                foreach (var type in workTypes)
                {
                    if (type.ID > 0)
                    {
                        WorkTypeUpdateDTO newTypeDTO = WorkTypeMapper.TreeDtoToUpdateDTO(type);
                        newTypeID = await _projectWorkDataService.Types.UpdateAsyncInTransaction(newTypeDTO, uow);
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

                        newTypeID = await _projectWorkDataService.Types.AddAsyncInTransaction(newTypeCreateDTO, uow);
                    }
                    if (type.WorkSpecs.Count > 0)
                    {
                        await SaveWorkSpecs(type.WorkSpecs, null, newTypeID, uow);
                    }
                    if (type.WorkTypes.Count > 0)
                    {
                        await SaveWorkTypes(type.WorkTypes, null, newTypeID, uow);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return true;
        }

        //wraped in Transaction
        private async Task<bool> SaveWorkSpecs(ICollection<WorkSpecUpdateDTO> workSpecs, int? categoryParentID, int? typeParentID, IUnitOfWork uow)
        {
            //TODO: make boolean flag later
            try
            {
                foreach (var workSpec in workSpecs)
                {
                    if (workSpec.ID > 0)
                    {
                        //TODO: add transaction overloading
                        await _projectWorkDataService.Specs.UpdateAsyncInTransaction(workSpec, uow);
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
                        await _projectWorkDataService.Specs.AddAsyncInTransaction(createDTO, uow);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return true;
        }
    }
}
