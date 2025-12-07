using Domain.Abstractions;
using Domain.Entities;
using DTO.Projects;
using MyApplication.Abstractions;
using MyApplication.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApplication
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepo;

        public ProjectService(IProjectRepository projectRepo)
        {
            _projectRepo = projectRepo;
        }

        public async Task<ProjectDTO> GetByIdAsync(int projectId)
        {
            if (projectId <= 0)
                return null;
            var project = await _projectRepo.GetByID(projectId);
            ProjectDTO projectDTO = ProjectMapper.DomainToDto(project);
            return projectDTO;
        }

        /// <summary>
        /// Creates and adds a new project to the system.
        /// It maps a ProjectCreateDto to a new Project domain entity and adds it via the repository.
        /// </summary>
        /// <param name="dto">The DTO containing the data for the new project.</param>
        // Done
        public async Task<bool> AddNewAsync(ProjectCreateDTO dto)
        {
            if (dto == null)
                throw new ArgumentException("Project data is required");
            try
            {
                if (_projectRepo.IsProjectExistByName(dto.Name))
                    throw new ArgumentException("Project already exists!");

                var project = ProjectMapper.CreateDtoToDomain(dto);

                return await _projectRepo.AddNewAsync(project);
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
        // done
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
        /// <summary>
        /// Archives a project by marking it as deleted. This is a soft delete.
        /// It reuses the UpdateProject method to perform the operation.
        /// </summary>
        /// <param name="projectId">The ID of the project to archive.</param>
        /// <param name="modifiedBy">The ID of the user performing the action.</param>
        // Done
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

        // done
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

        // done
        public async Task<IEnumerable<ProjectDTO>> GetAllAsync()
        {
            try
            {
                IEnumerable<Project> projects = await _projectRepo.FindAllFullAsync();
                //var addresses = await _addressRepo.FindAllAsync();
                return ProjectMapper.DomainsToDtoList(projects);
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<ProjectDTO>();
            }
        }

        // done
        public async Task<IEnumerable<ProjectDTO>> SearchProjectsAsync(string searchTerm)
        {
            // TODO: Simulate an asynchronous I/O operation
            await Task.Delay(100);

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                var allProjects = await _projectRepo.FindAllFullAsync();
                //var allAddresses = await _addressRepo.FindAllAsync();
                var allProjectsDTO = ProjectMapper.DomainsToDtoList(allProjects);
                return allProjectsDTO;
            }

            string normalizedSearchTerm = searchTerm.Trim().ToLowerInvariant();
            var projects = await _projectRepo.FindAllFullAsync();
            //var addresses = await _addressRepo.FindAllAsync();
            var AllProjectsDTO = ProjectMapper.DomainsToDtoList(projects);
            return AllProjectsDTO.Where(p =>
                p.Name.ToLowerInvariant().Contains(normalizedSearchTerm) ||
                p.ProjectCode.ToLowerInvariant().Contains(normalizedSearchTerm) ||
                p.ProjectType.ToLowerInvariant().Contains(normalizedSearchTerm) ||
                p.Description.ToLowerInvariant().Contains(normalizedSearchTerm)
            ).ToList(); /*.Select(p => ProjectMapper.DomainToDtoWithAddress(p))*/
        }

        /// <summary>
        /// Get Minimal data Projects List
        /// </summary>
        /// <returns>IEnumerable of type ProjectMinDTO </returns>
        // done
        public async Task<List<ProjectMinDTO>> GetAllMinAsync()
        {
            try
            {
                IEnumerable<Project> projects = await _projectRepo.FindAllFullAsync();

                return projects.Select(p => ProjectMapper.DomainsToMinDto(p)).ToList();
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<ProjectMinDTO>().ToList();
            }
        }

        //******************************* Mock Data *****************************
        public List<ProjectMinDTO> GetMockProjects()
        {
            return new List<ProjectMinDTO>
        {
            new ProjectMinDTO(1, "E-Commerce Website", false, 40, "type"),
            new ProjectMinDTO(2, "Mobile Banking App", false, 4, "type"),
            new ProjectMinDTO(3, "Inventory Management System", false, 45, "type"),
            new ProjectMinDTO(4, "Customer Relationship Management", false, 4, "type"),
            new ProjectMinDTO(5, "Analytics Dashboard", false, 4, "type"),
            new ProjectMinDTO(6, "IoT Smart Home System", false, 4, "type"),
            new ProjectMinDTO(7, "Learning Management Platform", false, 4, "type"),
            new ProjectMinDTO(8, "Healthcare Patient Portal", false, 4, "type"),
            new ProjectMinDTO(9, "Real Estate Listing Service", false, 4, "type"),
            new ProjectMinDTO(10, "Social Media Analytics Tool", false, 4, "type")
        };
        }
    }
}
