using DTO.Works.WorkSpecs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApplication.Abstractions.Works
{
    public interface IWorkSpecService
    {
        Task<List<WorkSpecUpdateDTO>> GetAllSpecsForCategoriesAndTypesAsync(int projectID);
        Task<WorkSpecUpdateDTO> GetByIdAsync(int id);
        Task<IEnumerable<WorkSpecUpdateDTO>> GetAllAsync();
        Task<bool> AddAsync(WorkSpecCreateDTO spec);
        Task<bool> UpdateAsync(WorkSpecUpdateDTO spec);
        Task<bool> DeleteAsync(int id);
    }
}
