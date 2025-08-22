using BLL.Domain;
using BLL.Interfaces;
using BLL.Mappers.Subcontractors;
using DAL.Interfaces;
using DAL.Interfaces.Subcontractor;
using DTO.Subcontractor;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class SubcontractorService : ISubcontractorService
    {
        private readonly ISubcontractorRepository _subcontractorRepo;
        private readonly ISubcontractorUniquenessChecker _uniquenessChecker;
        public SubcontractorService(ISubcontractorRepository subcontractorRepo, ISubcontractorUniquenessChecker uniquenessChecker)
        {
            _subcontractorRepo = subcontractorRepo;
            _uniquenessChecker = uniquenessChecker;
        }

        public bool AddNew(SubcontractorDTO subcontractorDTO)
        {            
            var domain = Subcontractor.Create(subcontractorDTO, _uniquenessChecker);
            var entityDTO = SubcontractorMapper.DomainToEntityDTO(domain);
            return _subcontractorRepo.AddNew(entityDTO);
        }
        public bool Update(SubcontractorDTO dto)
        {
            var entityDTO = _subcontractorRepo.GetById(dto.ID);
            if (entityDTO == null)
                throw new InvalidOperationException("Subcontractor not found.");

            // Convert back to Domain
            var domain = SubcontractorMapper.EntityToDomain(entityDTO);

            // Apply update rules
            domain.Update(dto, _uniquenessChecker);

            // Save changes
            var updatedEntityDTO = SubcontractorMapper.DomainToEntityDTO(domain);
            return _subcontractorRepo.Update(updatedEntityDTO);
        }

        public bool Delete(int id)
        {
            return _subcontractorRepo.Delete(id);
        }

        public async Task<List<SubcontractorDTO>> GetAllAsync()
        {
            List<SubcontractorDTO> allDTOs = new List<SubcontractorDTO>();
            var originalDtos = await _subcontractorRepo.GetAllAsync();
            // TODO: will convert directly to DTO       
            allDTOs = originalDtos.ConvertAll((p) => SubcontractorMapper.EntityToDTO(p));
            return allDTOs;
        }

        public SubcontractorDTO GetById(int id)
        {
            var entityDTO = _subcontractorRepo.GetById(id);
            return SubcontractorMapper.EntityToDTO(entityDTO);
        }

    }
}
