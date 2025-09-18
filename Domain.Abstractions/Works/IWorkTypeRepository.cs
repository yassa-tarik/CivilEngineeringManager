using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions.Works
{
    public interface IWorkTypeRepository
    {
        Task<WorkType> GetByIdAsync(int id);
        Task<IEnumerable<WorkType>> GetAllAsync();
        Task<WorkType> AddAsync(WorkType type);
        Task UpdateAsync(WorkType type);
        Task DeleteAsync(int id);
    }
}
