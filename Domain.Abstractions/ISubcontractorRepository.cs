using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Abstractions
{
    public interface ISubcontractorRepository
    {
        Task<List<Subcontractor>> FindAllAsync();
        Task<Subcontractor> GetByID(int subcontractorID);
        Task<bool> AddNewAsync(Subcontractor subcontractor);
        Task<bool> IsSubcontractorExistByName(string CompanyName);
    }
}
