using Domain.Abstractions;
using DTO.Works.WorkTypes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApplication.Abstractions.Works
{
    /// <summary>
    /// Defines the contract for all data access operations related to WorkType.
    /// </summary>
    public interface IWorkTypeService
    {
        Task<WorkTypeDTO> GetByIdAsync(int id);
        Task<IEnumerable<WorkTypeDTO>> GetAllForCategoriesRootsAsync(int projectID);
        Task<int> AddAsync(WorkTypeCreateDTO type);
        Task<int> AddAsyncInTransaction(WorkTypeCreateDTO type, IUnitOfWork uow);
        Task<int> UpdateAsync(WorkTypeUpdateDTO type);
        Task<int> UpdateAsyncInTransaction(WorkTypeUpdateDTO type, IUnitOfWork uow);
        Task DeleteAsync(int id);
        // mock data
        Task<ICollection<WorkTypeDTO>> GetAllForCategoryAsync(int categoryID);
    }
}
