using DTO.Subcontractors;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApplication.Abstractions
{
    public interface ISubcontractorService
    {
        Task<SubcontractorDTO> GetByIdAsync(int subcontractorID);
        Task<bool> AddNewAsync(SubcontractorCreateDTO dto);

        //Task<bool> UpdateAsync(ProjectUpdateDTO dto);
        Task<List<SubcontractorDTO>> GetAllAsync();

        Task<bool> IsSubcontractorExistByName(string name);
    }
}
