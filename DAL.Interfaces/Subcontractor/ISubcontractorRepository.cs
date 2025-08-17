using DAL.Contracts.SubcontractorEntity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ISubcontractorRepository
    {
        bool AddNew(SubcontractorEntityDTO EntityDTO);
        SubcontractorEntityDTO GetById(int id);
        Task<List<SubcontractorEntityDTO>> GetAllAsync();
        bool Update(SubcontractorEntityDTO EntityDTO);
        bool Delete(int id);
        bool ExistsById(int id);
        bool ExistsByName(string raisonSocial);
    }
}
