using DTO.Works.AssignedWorks;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApplication.Abstractions.Works
{
    public interface IAssignedWorkService
    {
        Task<List<AssignedWorkUpdateDTO>> GetAllAssignedWorksForProjectAndSubcontractorAsync(int projectID, int subcontractorID);
        Task<bool> AddAsync(AssignedWorkCreateDTO assignedWork);
    }
}
