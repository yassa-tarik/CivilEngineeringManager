using Domain.Abstractions.Works;
using DTO.Works.AssignedWorks;
using MyApplication.Abstractions.Works;
using MyApplication.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApplication.Services.Works
{
    public class AssignedWorkService : IAssignedWorkService
    {
        private readonly IAssignedWorkRepository _assignedWorkRepo;

        public AssignedWorkService(IAssignedWorkRepository assignedWorkRepo)
        {
            _assignedWorkRepo = assignedWorkRepo;
        }

        public Task<bool> AddAsync(AssignedWorkCreateDTO assignedWork)
        {
            throw new NotImplementedException();
        }

        public async Task<List<AssignedWorkUpdateDTO>> GetAllAssignedWorksForProjectAndSubcontractorAsync(int projectID, int subcontractorID)
        {
            var assignedWorks = await _assignedWorkRepo.GetAllAssignedWorksForProjectAndSubcontractorAsync(projectID, subcontractorID);
            var assignedWorkDTO = assignedWorks.Select(ws => AssignedWorkMapper.DomainToDto(ws)).ToList();
            return assignedWorkDTO;
        }
    }
}
