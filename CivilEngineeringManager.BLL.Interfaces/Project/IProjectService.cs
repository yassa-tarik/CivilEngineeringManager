using DTO.Project;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IProjectService
    {
        Task<List<ProjectDTO>> GetAllFullAsync();
        Task<List<ProjectMinimalDTO>> GetAllMinimalProjectsAsync();
        void AddProject(ProjectDTO dto);
        void UpdateProject(ProjectDTO dto);
        void DeleteProject(int projectId);
        //List<ProjectMinimalDTO> GetAllMinimalProjects();
    }
}
