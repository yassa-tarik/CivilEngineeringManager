using DTO.Works.WorkSpecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Abstractions.Works
{
    public interface IWorkSpecSerice
    {
        Task<WorkSpecDTO> GetByIdAsync(int id);
        Task<IEnumerable<WorkSpecDTO>> GetAllAsync();
        Task<WorkSpecDTO> AddAsync(WorkSpecDTO spec);
        Task UpdateAsync(WorkSpecDTO spec);
        Task DeleteAsync(int id);
    }
}
