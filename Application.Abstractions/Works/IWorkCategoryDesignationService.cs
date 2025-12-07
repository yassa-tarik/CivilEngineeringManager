using DTO.Works.WorkCategoryDesignations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApplication.Abstractions.Works
{
    public interface IWorkCategoryDesignationService
    {
        Task<WorkCategoryDesignationUpdateDTO> GetByIdAsync(int id);
        //Dictionary<int, string> GetAllAsync();
        bool isExistsByName(string designation);
        Task<Dictionary<int, WorkCategoryDesignationUpdateDTO>> GetAllAsync();
        Task<int> AddAsync(WorkCategoryDesignationCreateDTO category);
        Task<bool> UpdateAsync(WorkCategoryDesignationUpdateDTO category);
        //Task DeleteAsync(int id);
    }
}
