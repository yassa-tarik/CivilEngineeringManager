using Domain.Abstractions;
using Domain.Entities;
using DTO.Subcontractors;
using MyApplication.Abstractions;
using MyApplication.Mappers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApplication.Services
{
    public class SubcontractorService : ISubcontractorService
    {

        private readonly ISubcontractorRepository _subcontractorRepo;

        public SubcontractorService(ISubcontractorRepository subcontractorRepo)
        {
            _subcontractorRepo = subcontractorRepo;
        }
        // Done
        public async Task<SubcontractorDTO> GetByIdAsync(int subcontractorID)
        {
            if (subcontractorID <= 0)
                return null;
            var subcontractor = await _subcontractorRepo.GetByID(subcontractorID);
            SubcontractorDTO subcontractorDto = SubcontractorMapper.DomainToDTO(subcontractor);
            return subcontractorDto;
        }

        /// <summary>
        /// Creates and adds a new Subcontractor to the system.
        /// It maps a SubcontractorCreateDto to a new Subcontractor domain entity and adds it via the repository.
        /// </summary>
        /// <param name="dto">The DTO containing the data for the new Subcontractor.</param>
        // Done
        public async Task<bool> AddNewAsync(SubcontractorCreateDTO dto)
        {
            if (dto == null)
                throw new ArgumentException("Subcontractor data is required");
            try
            {
                if (await _subcontractorRepo.IsSubcontractorExistByName(dto.CompanyName))
                    throw new ArgumentException("Subcontractor already exists!");

                var subcontractor = SubcontractorMapper.CreateDTOToDomain(dto);

                return await _subcontractorRepo.AddNewAsync(subcontractor);
            }
            catch (InvalidOperationException ex)
            {
                //TODO: _logger.LogError(ex, "Failed to create project");
                throw new InvalidOperationException(ex.Message);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /*
               public async Task<bool> UpdateAsync(ProjectUpdateDTO dto)
               {
                   if (dto == null)
                       throw new ArgumentNullException(nameof(dto));

                   Project existing = await _projectRepo.GetByID(dto.ID);
                   if (existing == null)
                       throw new KeyNotFoundException("Project not found!");

                   Address newAddress = AddressMapper.DTOToDomain(dto.AddressDto);

                   existing.Update(
                       dto.Name,
                       dto.ProjectCode,
                       dto.StartDate,
                       dto.Duration,
                       dto.ProjectType,
                       dto.Description,
                       dto.IsActive,
                       dto.LandRegistry,
                       dto.SubdivisionPermitNumber,
                       dto.SubdivisionPermitDate,
                       dto.ConstructionPermitNumber,
                       dto.ConstructionPermitDate,
                       dto.DeedVolume,
                       dto.DeedNumber,
                       dto.DeedFolio,
                       dto.LandBook,
                       dto.LandBookDate,
                       dto.LandBookBy,
                       dto.IsSpecCompleted,
                       dto.Progress,
                       newAddress
                       );
                   return await _projectRepo.UpdateAsync(existing);
               }

               public async Task<ProjectDTO> GetProjectDetails(int projectId)
               {
                   try
                   {
                       Project project = await _projectRepo.GetByID(projectId);
                       if (project == null)
                       {
                           throw new InvalidOperationException($"Project with ID {projectId} not found.");
                       }
                       return ProjectMapper.DomainToDto(project);
                   }
                   catch (Exception ex)
                   {
                       throw new Exception($"An unexpected error occurred while fetching project {projectId}: {ex.Message}");
                   }
               }


               public async Task<bool> ArchiveAsync(int projectId, int modifiedBy)
               {
                   try
                   {
                       var existing = await _projectRepo.GetByID(projectId);
                       if (existing == null) throw new InvalidOperationException("project not found!");
                       return existing.MarkAsArchived(modifiedBy);
                   }
                   catch (Exception ex)
                   {
                       throw new Exception($"An unexpected error occurred while archiving project {projectId}: {ex.Message}");
                   }
               }
         */
        public async Task<List<SubcontractorDTO>> GetAllAsync()
        {
            try
            {
                List<Subcontractor> subcontractors = await _subcontractorRepo.FindAllAsync();
                //var addresses = await _addressRepo.FindAllAsync();
                return SubcontractorMapper.DomainsToDtoList(subcontractors);
            }
            catch (Exception ex)
            {
                return new List<SubcontractorDTO>();
            }
        }

        public Task<bool> IsSubcontractorExistByName(string companyName)
        {
            return _subcontractorRepo.IsSubcontractorExistByName(companyName);
        }
    }
}
