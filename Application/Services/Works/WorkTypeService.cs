using Domain.Abstractions;
using Domain.Abstractions.Works;
using Domain.Entities;
using DTO.Works.WorkTypes;
using MyApplication.Abstractions.Works;
using MyApplication.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApplication.Services.Works
{
    public class WorkTypeService : IWorkTypeService
    {
        private readonly IWorkTypeRepository _workTypeRepo;

        public WorkTypeService(IWorkTypeRepository workTypeRepo)
        {
            _workTypeRepo = workTypeRepo;
        }

        // Done
        public Task<int> AddAsync(WorkTypeCreateDTO typeDTO)
        {
            if (typeDTO == null)
                throw new ArgumentException("WorkType data is required");

            try
            {
                // 1- check uniqueness
                WorkType workType = WorkTypeMapper.CreateDtoToDomain(typeDTO);

                return _workTypeRepo.AddNewAsync(workType);
            }
            catch (Exception)
            {
                // TODO: logging
                throw;
            }
        }
        // Done
        public Task<int> AddAsyncInTransaction(WorkTypeCreateDTO typeDTO, IUnitOfWork uow)
        {
            if (typeDTO == null)
                throw new ArgumentException("WorkType data is required");

            try
            {
                // 1- check uniqueness
                WorkType workType = WorkTypeMapper.CreateDtoToDomain(typeDTO);

                return _workTypeRepo.AddNewAsyncInTransaction(workType, uow);
            }
            catch (Exception)
            {
                // TODO: logging
                throw;
            }
        }
        public async Task<int> UpdateAsync(WorkTypeUpdateDTO typeDTO)
        {
            //TODO: should check the returned int if -1, 0 or >0
            if (typeDTO == null)
                throw new ArgumentException("WorkType must have data!");

            var existing = await _workTypeRepo.GetByIdAsync(typeDTO.ID);

            if (existing == null)
                throw new ArgumentException("WorkType not found!");

            existing.Update(typeDTO.WorkCategory_ID, typeDTO.Parent_ID, typeDTO.Designation);

            return await _workTypeRepo.UpdateAsync(existing);
        }
        public async Task<int> UpdateAsyncInTransaction(WorkTypeUpdateDTO typeDTO, IUnitOfWork uow)
        {
            //TODO: should check the returned int if -1, 0 or >0
            if (typeDTO == null)
                throw new ArgumentException("WorkType must have data!");

            var existing = await _workTypeRepo.GetByIdAsync(typeDTO.ID);

            if (existing == null)
                throw new ArgumentException("WorkType not found!");

            existing.Update(typeDTO.WorkCategory_ID, typeDTO.Parent_ID, typeDTO.Designation);

            return await _workTypeRepo.UpdateAsync(existing);
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<WorkTypeDTO>> GetAllForCategoryAsync(int categoryID)
        {
            var workTypes = await _workTypeRepo.GetAllForCategoryAsync(categoryID);

            var workTypesDTOs = workTypes.Select(c => WorkTypeMapper.DomainToDto(c)).ToList();
            return workTypesDTOs;
        }

        public Task<WorkTypeDTO> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<WorkTypeDTO>> GetAllForCategoriesRootsAsync(int projectID)
        {
            var workTypes = await _workTypeRepo.GetAllForCategoriesRootsAsync(projectID);
            var workTypesDTO = workTypes.Select(wt => WorkTypeMapper.DomainToDto(wt));
            return workTypesDTO;
        }
    }
}
