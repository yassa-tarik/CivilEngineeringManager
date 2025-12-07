using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Abstractions.Works
{
    public interface IWorkTypeRepository
    {
        Task<List<WorkType>> GetAllForCategoriesRootsAsync(int projectID);
        Task<WorkType> GetByIdAsync(int id);
        Task<int> AddNewAsync(WorkType type);
        Task<int> AddNewAsyncInTransaction(WorkType type, IUnitOfWork uow);
        Task<int> UpdateAsync(WorkType type);
        Task<int> UpdateAsync(WorkType type, IUnitOfWork uow);
        Task DeleteAsync(int id);
        Task<IEnumerable<WorkType>> GetAllForCategoryAsync(int categoryID);
    }
}
