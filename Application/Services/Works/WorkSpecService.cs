using Domain.Abstractions;
using Domain.Abstractions.Works;
using Domain.Entities;
using DTO.Works.WorkSpecs;
using MyApplication.Abstractions.Works;
using MyApplication.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApplication.Services.Works
{
    public class WorkSpecService : IWorkSpecService
    {
        private readonly IWorkSpecRepository _workSpecRepo;
        public WorkSpecService(IWorkSpecRepository workSpecRepo)
        {
            _workSpecRepo = workSpecRepo;
        }
        //Done
        public Task<bool> AddAsync(WorkSpecCreateDTO specDTO)
        {
            if (specDTO == null)
                throw new ArgumentException("WorkSpec data is required");

            try
            {
                // 1- check uniqueness
                WorkSpec workSpec = WorkSpecMapper.CreateDtoToDomain(specDTO);

                return _workSpecRepo.AddNewAsync(workSpec);
            }
            catch (Exception)
            {
                // TODO: logging
                throw;
            }
        }
        //Done
        public Task<bool> AddAsyncInTransaction(WorkSpecCreateDTO specDTO, IUnitOfWork uow)
        {
            if (specDTO == null)
                throw new ArgumentException("WorkSpec data is required");

            try
            {
                // 1- check uniqueness
                WorkSpec workSpec = WorkSpecMapper.CreateDtoToDomain(specDTO);

                return _workSpecRepo.AddNewAsyncInTransaction(workSpec, uow);
            }
            catch (Exception)
            {
                // TODO: logging
                throw;
            }
        }
        //Done
        public async Task<bool> UpdateAsync(WorkSpecUpdateDTO specDTO)
        {
            if (specDTO == null)
                throw new ArgumentException("WorkSpec should hav data!");

            var existing = await _workSpecRepo.GetByIdAsync(specDTO.ID);

            if (existing == null)
                throw new ArgumentException("WorkSpec not found!");

            existing.Update(specDTO.WorkCategory_ID, specDTO.WorkType_ID, specDTO.Designation, specDTO.Unit, specDTO.UnitPrice, specDTO.Quantity, specDTO.VAT, specDTO.IsAssigned);

            return await _workSpecRepo.UpdateAsync(existing);
        }
        //Done
        public async Task<bool> UpdateAsyncInTransaction(WorkSpecUpdateDTO specDTO, IUnitOfWork uow)
        {
            if (specDTO == null)
                throw new ArgumentException("WorkSpec should hav data!");
            try
            {
                var existing = await _workSpecRepo.GetByIdAsync(specDTO.ID);

                if (existing == null)
                    throw new ArgumentException("WorkSpec not found!");

                existing.Update(specDTO.WorkCategory_ID, specDTO.WorkType_ID, specDTO.Designation, specDTO.Unit, specDTO.UnitPrice, specDTO.Quantity, specDTO.VAT, specDTO.IsAssigned);

                return await _workSpecRepo.UpdateAsync(existing);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<WorkSpecUpdateDTO>> GetAllSpecsForProjectAsync(int projectID, bool isAssigned = false)
        {
            var workSpecs = await _workSpecRepo.GetAllSpecsForProjectAsync(projectID, isAssigned);
            var workSpecsDTO = workSpecs.Select(ws => WorkSpecMapper.DomainToDto(ws)).ToList();
            return workSpecsDTO;
        }
        public async Task<List<WorkSpecUpdateDTO>> GetAllSpecsForProjectAndSubcontractorAsync(int projectID, int subcontractorID)
        {
            var workSpecs = await _workSpecRepo.GetAllSpecsForProjectAndSubcontractorAsync(projectID, subcontractorID);
            var workSpecsDTO = workSpecs.Select(ws => WorkSpecMapper.DomainToDto(ws)).ToList();
            return workSpecsDTO;
        }
        public Task<bool> DeleteAsync(int id)
        {
            throw new NotFiniteNumberException();
        }

        /// <summary>
        /// Retrieves all work specifications and maps them to WorkSpecDTO objects.
        /// This method demonstrates the service logic even with an empty repository.
        /// </summary>
        /// <returns>A collection of WorkSpecDTO objects.</returns>      
        public async Task<IEnumerable<WorkSpecUpdateDTO>> GetAllAsync()
        {
            var specs = await _workSpecRepo.GetAllAsync();

            // The DTO mapping logic is here, even if the result is an empty collection.
            var specDTOs = specs.Select(s => WorkSpecMapper.DomainToDto(s)).ToList();

            return specDTOs;
        }

        public Task<WorkSpecUpdateDTO> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
