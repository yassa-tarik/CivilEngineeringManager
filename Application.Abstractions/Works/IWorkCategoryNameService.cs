using DTO.Works.WorkCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Abstractions.Works
{
    public interface IWorkCategoryNameService
    {
        Task<WorkCategoryDTO> GetByIdAsync(int id);
        Dictionary<int, string> GetAllAsync();
        Task<WorkCategoryDTO> AddAsync(WorkCategoryDTO category);
        Task UpdateAsync(WorkCategoryDTO category);
        Task DeleteAsync(int id);
    }
}
