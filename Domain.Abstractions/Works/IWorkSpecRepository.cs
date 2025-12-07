using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Abstractions.Works
{
    public interface IWorkSpecRepository
    {
        Task<List<WorkSpec>> GetAllSpecsForProjectAsync(int projectID, bool isAssigned);
        Task<List<WorkSpec>> GetAllSpecsForProjectAndSubcontractorAsync(int projectID, int subcontractorID);
        Task<WorkSpec> GetByIdAsync(int id);
        Task<bool> AddNewAsync(WorkSpec spec);
        Task<bool> AddNewAsyncInTransaction(WorkSpec spec, IUnitOfWork uow);
        Task<bool> UpdateAsyncInTransaction(WorkSpec spec, IUnitOfWork uow);
        Task<bool> UpdateAsync(WorkSpec spec);
        Task DeleteAsync(int id);

        //mock data
        Task<IEnumerable<WorkSpec>> GetAllAsync();
    }
}
