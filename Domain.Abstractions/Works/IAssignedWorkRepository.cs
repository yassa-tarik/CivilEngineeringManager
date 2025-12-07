using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Abstractions.Works
{
    public interface IAssignedWorkRepository
    {
        Task<List<AssignedWork>> GetAllAssignedWorksForProjectAndSubcontractorAsync(int projectID, int subcontractorID);
    }
}
