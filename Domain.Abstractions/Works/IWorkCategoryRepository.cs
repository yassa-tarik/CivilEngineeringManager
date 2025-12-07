using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Abstractions.Works
{
    public interface IWorkCategoryRepository
    {
        Task<WorkCategory> GetByIdAsync(int id);
        Task<IEnumerable<WorkCategory>> GetAllWorkCategoriesForProjectAsync(int projectID);
        Task<int> AddNewAsync(WorkCategory category);
        Task<int> AddNewAsyncInTransaction(WorkCategory category, IUnitOfWork uow);
        Task<int> UpdateAsync(WorkCategory category);
        Task<int> UpdateAsyncInTransaction(WorkCategory category, IUnitOfWork uow);
        Task DeleteAsync(int id);
    }
}
