
using DTO.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Abstractions
{
    public interface IProjectService
    {
        Task<bool> AddNewAsync(ProjectCreateDTO dto);
        Task<bool> UpdateAsync(ProjectUpdateDTO dto);
        Task<bool> ArchiveAsync(int projectId, int modifiedBy);
        Task<IEnumerable<ProjectDTO>> SearchProjectsAsync(string searchTerm);
        Task<IEnumerable<ProjectMinDTO>> GetAllMinAsync();
        //************************* MOCK Data ****************************
        List<ProjectMinDTO> GetMockProjects();
    }
}
