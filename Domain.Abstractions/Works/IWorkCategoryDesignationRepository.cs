using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Abstractions.Works
{
    public interface IWorkCategoryDesignationRepository
    {
        Task<int> AddNewAsync(WorkCategoryDesignation category);
        Task<WorkCategoryDesignation> GetByIdAsync(int iD);
        bool isDesignationExists(string designation);
        Task<bool> UpdateAsync(WorkCategoryDesignation category);
        Task<List<WorkCategoryDesignation>> GetAllAsync();
    }
}
