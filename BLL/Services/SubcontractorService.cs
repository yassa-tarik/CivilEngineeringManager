using BLL.Domain;
using BLL.Interfaces;
using BLL.Mappers.Subcontractors;
using DAL.Contracts.SubcontractorEntity;
using DAL.Interfaces;
using DTO.Subcontractor;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class SubcontractorService : ISubcontractorService
    {
        private readonly ISubcontractorRepository _subcontractorRepo;
        public SubcontractorService(ISubcontractorRepository subcontractorRepo)
        {
            _subcontractorRepo = subcontractorRepo;
        }

        public bool AddNew(SubcontractorDTO subcontractorDTO)
        {
            // Check existence before update
            if (_subcontractorRepo.ExistsByName(subcontractorDTO.RaisonSocial))
            {
                // Optional: throw or return false
                throw new InvalidOperationException("Subcontractor already exist.");
            }
            var domain = Subcontractor.AddEdit(subcontractorDTO);
            var entityDTO = SubcontractorMapper.DomainToEntityDTO(domain);
            return _subcontractorRepo.AddNew(entityDTO);
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
            var allDomains = originalDtos.ConvertAll((p) => SubcontractorMapper.EntityToDomain(p));
            allDTOs = allDomains.ConvertAll((p) => SubcontractorMapper.DomainToDTO(p));
            return allDTOs;
        }

        public SubcontractorDTO GetById(int id)
        {
            var entityDTO = _subcontractorRepo.GetById(id);
            var domain = SubcontractorMapper.EntityToDomain(entityDTO);
            return SubcontractorMapper.DomainToDTO(domain);
        }

        public bool Update(SubcontractorDTO subcontractorDTO)
        {
            // Check existence before update
            if ( ! _subcontractorRepo.ExistsById(subcontractorDTO.ID))
            {
                // Optional: throw or return false
                throw new InvalidOperationException("Subcontractor doesn't exist.");
            }
            var domain = Subcontractor.AddEdit(subcontractorDTO);
            var entityDTO = SubcontractorMapper.DomainToEntityDTO(domain);
            return _subcontractorRepo.Update(entityDTO);
        }
    }
}
