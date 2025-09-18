using DTO.Works.WorkCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Abstractions.Works
{
    /// <summary>
    /// Defines the contract for all data access operations related to WorkCategory.
    /// </summary>
    public interface IWorkCategoryService
    {
        Task<WorkCategoryDTO> GetByIdAsync(int id);
        Task<ICollection<WorkCategoryDTO>> GetAllAsync();
        Task<WorkCategoryDTO> AddAsync(WorkCategoryDTO category);
        Task UpdateAsync(WorkCategoryDTO category);
        Task DeleteAsync(int id);
    }
}
