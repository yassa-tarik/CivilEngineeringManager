using DTO.Subcontractor;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ISubcontractorService
    {
        bool AddNew(SubcontractorDTO subcontractorDTO);
        SubcontractorDTO GetById(int id);
        Task<List<SubcontractorDTO>> GetAllAsync();
        bool Update(SubcontractorDTO subcontractorDTO);
        bool Delete(int id);
    }
}
