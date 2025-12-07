
using DTO.Projects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApplication.Abstractions
{
    public interface IProjectService
    {
        Task<ProjectDTO> GetByIdAsync(int projectId);
        Task<bool> AddNewAsync(ProjectCreateDTO dto);
        Task<bool> UpdateAsync(ProjectUpdateDTO dto);
        Task<bool> ArchiveAsync(int projectId, int modifiedBy);
        Task<IEnumerable<ProjectDTO>> SearchProjectsAsync(string searchTerm);
        Task<List<ProjectMinDTO>> GetAllMinAsync();
        //************************* MOCK Data ****************************
        //List<ProjectMinDTO> GetMockProjects();
    }
}
