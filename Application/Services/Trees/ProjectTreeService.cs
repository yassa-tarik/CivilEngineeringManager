using Domain.Abstractions.Works;
using DTO.TreeDTOs;
using DTO.Works.WorkSpecs;
using MyApplication.Abstractions;
using MyApplication.Abstractions.Works;
using MyApplication.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Services.Trees
{
    /// <summary>
    /// A service responsible for retrieving and building a hierarchical tree of WorkCategories, WorkTypes, and WorkSpecs.
    /// </summary>
    public class ProjectTreeService : IProjectTreeService
    {   
         private readonly IProjectService _projectService;
         private readonly IWorkCategoryRepository _workCategoryRepo;
         private readonly IWorkTypeRepository _workTypeRepo;
         private readonly IWorkSpecRepository _workSpecRepo;
         private readonly IWorkCategoryService _workCategoryService;
        
         public ProjectTreeService(IProjectService projectService, IWorkCategoryRepository workCategoryRepository, IWorkTypeRepository workTypeRepository, IWorkSpecRepository workSpecRepository, IWorkCategoryService workCategoryService)
         {
             _projectService = projectService;
             _workCategoryRepo = workCategoryRepository;
             _workTypeRepo = workTypeRepository;
             _workSpecRepo = workSpecRepository;
            _workCategoryService = workCategoryService;
         }

        public async Task<ProjectTreeDTO> GetProjectTreeAsync(int projectID)
        {
            var projectMin = _projectService.GetMockProjects().Find(p => p.ID == projectID);
            if (projectMin == null)
                throw new Exception("project not found!");
            var projectTree = new ProjectTreeDTO(projectMin.ID, projectMin.Name);
            var categoryTrees = await GetWorkCategoryTreeAsync();
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
        public async Task<IEnumerable<WorkCategoryTreeDTO>> GetWorkCategoryTreeAsync()
        {
            //TODO: will fetch only lists for specific Project using ID
            // Step 1: Fetch all data from the database
            var allCategories = await _workCategoryService.GetAllAsync();
            //var allCategories = await _workCategoryRepo.GetAllAsync();
            var allWorkTypes = await _workTypeRepo.GetAllAsync();
            var allWorkSpecs = await _workSpecRepo.GetAllAsync();

            // Step 2.0: Group WorkSpecs by WorkCategoryID for efficient lookup
            var allWorkSpecsDTO = allWorkSpecs.Select(w => WorkSpecMapper.DomainToDto(w));
            var workSpecsByWorkCategory = allWorkSpecsDTO.Where(ws => ws.WorkCategory_ID != null).GroupBy(ws => ws.WorkCategory_ID)
                .ToDictionary(g => g.Key, g => g.ToList());

            // Step 2.1: Group WorkSpecs by WorkTypeID for efficient lookup
            var workSpecsByWorkType = allWorkSpecs.Where(ws => ws.WorkType_ID != null).GroupBy(ws => ws.WorkType_ID).ToDictionary(g => g.Key, g => g.ToList());

            // Step 3: Map all WorkTypes to their DTOs and build the hierarchy
            var workTypeMap = allWorkTypes.ToDictionary(
                wt => wt.ID,
                wt => new WorkTypeTreeDTO
                {
                    ID = wt.ID,
                    WorkCategoryID = wt.WorkCategory_ID,
                    ParentID = wt.Parent_ID,
                    Designation = wt.Designation,
                    // Assign WorkSpecs to their DTOs if they exist
                    WorkSpecs = workSpecsByWorkType.ContainsKey(wt.ID)
                        ? workSpecsByWorkType[wt.ID].Select(ws => new WorkSpecDTO
                        (
                            ws.ID,
                            ws.WorkCategory_ID,
                            ws.WorkType_ID,
                            ws.Designation,
                            ws.Unit,
                            ws.UnitPrice,
                            ws.Quantity,
                            ws.VAT
                        )).ToList() : new List<WorkSpecDTO>()
                });

            // Step 4: Build the parent-child relationships for WorkTypes
            foreach (var workType in workTypeMap.Values)
            {
                if (workType.ParentID.HasValue && workTypeMap.ContainsKey(workType.ParentID.Value))
                {
                    workTypeMap[workType.ParentID.Value].WorkTypes.Add(workType);
                }
            }

            // Step 5: Build the final tree by assigning top-level WorkTypes to Categories
            var categoryTrees = allCategories.Select(c => new WorkCategoryTreeDTO
            {
                ID = c.ID,
                Designation = c.WorkCategoryName,
                WorkTypes = workTypeMap.Values.Where(wt => wt.WorkCategoryID == c.ID && !wt.ParentID.HasValue).ToList(),
                WorkSpecs = workSpecsByWorkCategory.ContainsKey(c.ID)? workSpecsByWorkCategory[c.ID] : new List<WorkSpecDTO>()
            } ).ToList();

            return categoryTrees;
        }   


    }
}
