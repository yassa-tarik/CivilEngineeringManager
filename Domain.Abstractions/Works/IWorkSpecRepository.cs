using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions.Works
{
    public interface IWorkSpecRepository
    {
        Task<WorkSpec> GetByIdAsync(int id);
        Task<IEnumerable<WorkSpec>> GetAllAsync();
        Task<WorkSpec> AddAsync(WorkSpec spec);
        Task UpdateAsync(WorkSpec spec);
        Task DeleteAsync(int id);
    }
}
