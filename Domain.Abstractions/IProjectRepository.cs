using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Abstractions
{
    public interface IProjectRepository
    {
        Task<Project> GetByID(int projectID);
        Task<IEnumerable<Project>> SearchProjectsAsync(string searchTerm);
        // Full Project info
        Task<List<Project>> FindAllFullAsync();
        // Full Project info
        Task<List<Project>> FindAllMinimalAsync();
        Task<Project> AddAsync(Project project);
        Task<bool> UpdateAsync(Project project);
        Task DeleteAsync(int projectId);
        Task<bool> SaveProjectWithAddressAsync(Project project, Address address);
        List<Project> GetAllMinimal();
        bool IsProjectExist(int ID);
        bool IsProjectExistByName(string projectName);
        //****************** mock data *********************
        Task<IEnumerable<Project>> FindAll();
    }
}
