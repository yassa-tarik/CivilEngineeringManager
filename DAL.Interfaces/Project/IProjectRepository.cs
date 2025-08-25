using DAL.Contract.Project;
using DTO.Project;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IProjectRepository
    {
        Contract.Project.ProjectEntityDTO GetByID(int ID);

        // Full Project info
        Task<List<Contract.Project.ProjectEntityDTO>> GetAllFullAsync();

        // Full Project info
        Task<List<ProjectMinimalDTO>> GetAllMinimalAsync();

        bool AddNew(ProjectEntityDTO entityDto);

        bool Update(ProjectEntityDTO dto);

        bool Delete(int id);

        List<ProjectMinimalDTO> GetAllMinimal();

        bool IsProjectExist(int ID);
    }
}
