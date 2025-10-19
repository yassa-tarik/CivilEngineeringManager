using DTO.Works.WorkCategories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApplication.Abstractions.Works
{
    /// <summary>
    /// Defines the contract for all data access operations related to WorkCategory.
    /// </summary>
    public interface IWorkCategoryService
    {
        Task<WorkCategoryDTO> GetByIdAsync(int id);
        Task<ICollection<WorkCategoryDTO>> GetAllForProjectAsync(int projectID);
        Task<int> AddAsync(WorkCategoryCreateDTO category);
        Task<int> UpdateAsync(WorkCategoryUpdateDTO category);
        Task DeleteAsync(int id);
    }
}
