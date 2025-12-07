using Domain.Abstractions;
using DTO.Works.WorkSpecs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApplication.Abstractions.Works
{
    public interface IWorkSpecService
    {
        Task<List<WorkSpecUpdateDTO>> GetAllSpecsForProjectAsync(int projectID, bool isAssigned = false);
        Task<List<WorkSpecUpdateDTO>> GetAllSpecsForProjectAndSubcontractorAsync(int projectID, int subcontractorID);
        Task<WorkSpecUpdateDTO> GetByIdAsync(int id);
        Task<IEnumerable<WorkSpecUpdateDTO>> GetAllAsync();
        Task<bool> AddAsync(WorkSpecCreateDTO spec);
        Task<bool> AddAsyncInTransaction(WorkSpecCreateDTO spec, IUnitOfWork uow);
        Task<bool> UpdateAsync(WorkSpecUpdateDTO spec);
        Task<bool> UpdateAsyncInTransaction(WorkSpecUpdateDTO spec, IUnitOfWork uow);
        Task<bool> DeleteAsync(int id);
    }
}
