using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions.Works
{
    public interface IWorkCategoryRepository
    {
        Task<WorkCategory> GetByIdAsync(int id);
        Task<IEnumerable<WorkCategory>> GetAllAsync();
        Task<WorkCategory> AddAsync(WorkCategory category);
        Task UpdateAsync(WorkCategory category);
        Task DeleteAsync(int id);
    }
}
