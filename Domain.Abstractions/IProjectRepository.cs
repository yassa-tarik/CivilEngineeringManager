using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Abstractions
{
    public interface IProjectRepository
    {
        Task<Project> GetByID(int projectID);
        // Full Project info
        Task<List<Project>> FindAllFullAsync();
        // Full Project info
        Task<bool> UpdateAsync(Project project);
        Task DeleteAsync(int projectId);
        Task<bool> AddNewAsync(Project project);
        bool IsProjectExist(int ID);
        bool IsProjectExistByName(string projectName);
    }
}
