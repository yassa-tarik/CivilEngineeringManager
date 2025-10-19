using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Abstractions.Works
{
    public interface IWorkCategoryRepository
    {
        Task<WorkCategory> GetByIdAsync(int id);
        Task<IEnumerable<WorkCategory>> GetAllForProjectAsync(int projectID);
        Task<int> AddNewAsync(WorkCategory category);
        Task<int> UpdateAsync(WorkCategory category);
        Task DeleteAsync(int id);
    }
}
