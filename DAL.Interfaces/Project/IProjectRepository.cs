using DAL.Contract.Project;
using DTO.Project;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IProjectRepository
    {
        ProjectEntityDTO GetByID(int ID);

        // Full Project info
        Task<List<ProjectEntityDTO>> GetAllFullAsync();

        // Full Project info
        Task<List<ProjectMinimalDTO>> GetAllMinimalAsync();

        bool AddNew(ProjectDTO dto);

        bool Update(ProjectDTO dto);

        bool Delete(int id);

        List<ProjectMinimalDTO> GetAllMinimal();

        bool IsProjectExist(int ID);
    }
}
