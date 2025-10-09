using MyApplication.Abstractions.Works;
using Domain.Abstractions.Works;
using Domain.Entities;
using DTO.Works.WorkCategories;
using MyApplication.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Services.Works
{   /// <summary>
    /// A service responsible for managing WorkCategory entities.
    /// This service depends on an IWorkCategoryRepository for data access.
    /// </summary>
    public class WorkCategoryService : IWorkCategoryService
    {
        private readonly IWorkCategoryRepository _repository;
        private readonly IWorkCategoryNameService _categoryNameService;
        /// <summary>
        /// The service's constructor uses dependency injection to receive the repository.
        /// </summary>
        public WorkCategoryService(IWorkCategoryRepository repository, IWorkCategoryNameService categoryNameService)
        {
            _repository = repository;
            _categoryNameService = categoryNameService;
        }

        public Task<WorkCategoryDTO> AddAsync(WorkCategoryDTO category)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieves all work categories and maps them to WorkCategoryDTO objects.
        /// </summary>
        /// <returns>A collection of WorkCategoryDTO objects.</returns>
        public async Task<ICollection<WorkCategoryDTO>> GetAllAsync()
        {
            // Await all necessary data retrievals
            IEnumerable<WorkCategory> categories = await _repository.GetAllAsync();
            // Assuming this returns a Task<Dictionary<int, string>> and is awaited
            Dictionary<int, string> categoryNameMap = _categoryNameService.GetAllAsync();

            // Use LINQ Select to iterate and perform the lookup
            var categoryDTOs = categories.Select(category =>
            {
                // 1. Map the WorkCategory model to the DTO (e.g., using AutoMapper or a static method)
                var dto = WorkCategoryMapper.DomainToDto(category);

                // 2. Perform the dictionary lookup using the WorkCategoryName_ID
                if (categoryNameMap.TryGetValue(category.WorkCategoryName_ID, out string name))
                {
                    // 3. Set the name property on the DTO
                    // NOTE: Assuming WorkCategoryDTO has a 'Name' property for the full name.
                    dto.WorkCategoryName = name;
                }
                else
                {
                    // Handle case where ID is not found (e.g., log it or set a default value)
                    dto.WorkCategoryName = "Unknown Category";
                }
                return dto;
            }).ToList();

            return categoryDTOs;
        }

        public Task<WorkCategoryDTO> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(WorkCategoryDTO category)
        {
            throw new NotImplementedException();
        }
    }
}
