using Domain.Abstractions.Works;
using Domain.Entities;
using DTO.Works.WorkCategories;
using MyApplication.Abstractions.Works;
using MyApplication.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApplication.Services.Works
{ 
    /// <summary>
    /// A service responsible for managing WorkCategory entities.
    /// This service depends on an IWorkCategoryRepository for data access.
    /// </summary>
    public class WorkCategoryService : IWorkCategoryService
    {
        private readonly IWorkCategoryRepository _workCatRepo;
        private readonly IWorkCategoryDesignationService _categoryDesignationService;
        /// <summary>
        /// The service's constructor uses dependency injection to receive the repository.
        /// </summary>
        public WorkCategoryService(IWorkCategoryRepository repository, IWorkCategoryDesignationService categoryNameService)
        {
            _workCatRepo = repository;
            _categoryDesignationService = categoryNameService;
        }

        // Done
        public async Task<int> AddAsync(WorkCategoryCreateDTO category)
        {
            if (category == null)
                throw new ArgumentException("category must have data!");
            //TODO: will create 'isExistsByID' method
            var catDesignExist = await _categoryDesignationService.GetByIdAsync(category.WorkCategoryDesignation_ID) ?? throw new ArgumentException("WorkCategoryDesignation Not exists!");
            try
            {
                var newCategory = WorkCategoryMapper.CreateDtoToDomain(category);
                return await _workCatRepo.AddNewAsync(newCategory);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Done
        public async Task<int> UpdateAsync(WorkCategoryUpdateDTO catDTO)
        {
            if (catDTO == null)
                throw new ArgumentNullException("category must have data!");
            try
            {
                WorkCategory category = await _workCatRepo.GetByIdAsync(catDTO.ID)?? throw new ArgumentNullException("category not found!");
                category.Update(catDTO.WorkCategoryDesignation_ID);
                return await _workCatRepo.UpdateAsync(category);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieves all work categories and maps them to WorkCategoryDTO objects.
        /// </summary>
        /// <returns>A collection of WorkCategoryDTO objects.</returns>
        //TODO: will try using general DTO instead of UpdateDTO
        public async Task<ICollection<WorkCategoryDTO>> GetAllForProjectAsync(int projectID)
        {
            // Await all necessary data retrievals
            IEnumerable<WorkCategory> allCategories = await _workCatRepo.GetAllForProjectAsync(projectID);

            // Assuming this returns a Task<Dictionary<int, string>> and is awaited
            Dictionary<int, WorkCategoryDesignation> categoryDesignationMap = await  _categoryDesignationService.GetAllAsync();

            // Use LINQ Select to iterate and perform the lookup
            var categoryDTOs = allCategories.Select(category =>
            {
                // 1. Map the WorkCategory model to the DTO (e.g., using AutoMapper or a static method)
                var dto = WorkCategoryMapper.DomainToGeneralDto(category, categoryDesignationMap[category.ID]);
                
                return dto;
            }).ToList();

            return categoryDTOs;
        }

        public Task<WorkCategoryDTO> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
