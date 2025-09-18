using MyApplication.Abstractions.Works;
using MyApplication.Mappers;
using Domain.Abstractions.Works;
using DTO.Works.WorkSpecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Services.Works
{
    public class WorkSpecService : IWorkSpecSerice
    {
        private readonly IWorkSpecRepository _workSpecRepo;

        public WorkSpecService(IWorkSpecRepository workSpecRepo)
        {
            _workSpecRepo = workSpecRepo;
        }
        public Task<WorkSpecDTO> AddAsync(WorkSpecDTO spec)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieves all work specifications and maps them to WorkSpecDTO objects.
        /// This method demonstrates the service logic even with an empty repository.
        /// </summary>
        /// <returns>A collection of WorkSpecDTO objects.</returns>
        public async Task<IEnumerable<WorkSpecDTO>> GetAllAsync()
        {
            var specs = await _workSpecRepo.GetAllAsync();

            // The DTO mapping logic is here, even if the result is an empty collection.
            var specDTOs = specs.Select(s => WorkSpecMapper.DomainToDto(s)).ToList();

            return specDTOs;
        }

        public Task<WorkSpecDTO> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(WorkSpecDTO spec)
        {
            throw new NotImplementedException();
        }
    }
}
