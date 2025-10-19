using DTO.TreeDTOs;
using System.Threading.Tasks;

namespace MyApplication.Abstractions.Works
{
    public interface IProjectTreeService
    {
        Task<ProjectTreeDTO> GetProjectTreeAsync(int projectID);
        Task<bool> SaveProjectTree(ProjectTreeDTO projectTreeDTO);
    }
}
