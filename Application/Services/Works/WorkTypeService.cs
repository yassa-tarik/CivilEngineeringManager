using MyApplication.Abstractions.Works;
using MyApplication.Mappers;
using Domain.Abstractions.Works;
using DTO.Works.WorkTypes;
using MyApplication.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Services.Works
{
    internal class WorkTypeService : IWorkTypeService
    {
        private readonly IWorkTypeRepository _workTypeRepo;

        public WorkTypeService(IWorkTypeRepository workTypeRepo)
        {
            _workTypeRepo = workTypeRepo;
        }

        public Task<WorkTypeDTO> AddAsync(WorkTypeDTO type)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<WorkTypeDTO>> GetAllAsync()
        {
            var workTypes = await _workTypeRepo.GetAllAsync();

            var workTypesDTOs = workTypes.Select(c => WorkTypeMapper.DomainToDto(c)).ToList();
            return workTypesDTOs;
        }

        public Task<WorkTypeDTO> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(WorkTypeDTO type)
        {
            throw new NotImplementedException();
        }
    }
}
