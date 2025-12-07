using DTO.TreeDTOs;
using System.Threading.Tasks;

namespace MyApplication.Abstractions.Trees
{
    public interface IProjectWorkSpecsTreeService
    {
        Task<ProjectTreeDTO> GetProjectTreeForSpecificationsAsync(int projectID);
        Task<bool> SaveProjectTree(ProjectTreeDTO projectTreeDTO);
    }
}
