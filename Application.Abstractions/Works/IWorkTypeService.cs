using DTO.Works.WorkTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Abstractions.Works
{
    /// <summary>
    /// Defines the contract for all data access operations related to WorkType.
    /// </summary>
    public interface IWorkTypeService
    {
        Task<WorkTypeDTO> GetByIdAsync(int id);
        Task<ICollection<WorkTypeDTO>> GetAllAsync();
        Task<WorkTypeDTO> AddAsync(WorkTypeDTO type);
        Task UpdateAsync(WorkTypeDTO type);
        Task DeleteAsync(int id);
    }
}
