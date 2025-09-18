using Domain.Abstractions.Works;
using DTO.Works.WorkCategories;
using MyApplication.Abstractions.Works;
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
        /// <summary>
        /// The service's constructor uses dependency injection to receive the repository.
        /// </summary>
        public WorkCategoryService(IWorkCategoryRepository repository)
        {
            _repository = repository;
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
            var categories = await _repository.GetAllAsync();

            // The business logic of mapping from the internal model to the DTO
            // lives in the service layer, not the repository.
            var categoryDTOs = categories.Select(c => WorkCategoryMapper.DomainToDto(c)).ToList();
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
