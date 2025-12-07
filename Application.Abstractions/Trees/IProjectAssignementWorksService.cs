using DTO.TreeDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Abstractions.Trees
{
    public interface IProjectAssignementWorksService
    {
        Task<ProjectTreeDTO> GetProjectTreeForAssignementsAsync(int projectID);
        Task<bool> SaveProjectTree(ProjectTreeDTO projectTreeDTO);
    }
}
