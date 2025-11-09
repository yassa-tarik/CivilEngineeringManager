using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Abstractions.Works
{
    public interface IWorkSpecRepository
    {
        Task<List<WorkSpec>> GetAllSpecsForCategoriesAndTypesAsync(int projectID);
        Task<WorkSpec> GetByIdAsync(int id);
        Task<bool> AddNewAsync(WorkSpec spec);
        Task<bool> UpdateAsync(WorkSpec spec);
        Task DeleteAsync(int id);

        //mock data
        Task<IEnumerable<WorkSpec>> GetAllAsync();
    }
}
