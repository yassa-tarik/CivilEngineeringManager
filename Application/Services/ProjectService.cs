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
        private readonly IAddressRepository _addressRepo;

        public ProjectService(IProjectRepository projectRepo, IAddressRepository addressRepo)
        {
            _projectRepo = projectRepo;
            _addressRepo = addressRepo;
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
            // Check for existing project (consider making this atomic in repository)
            //if (await _projectRepo.ProjectExistsByNameAsync(dto.Name))
            //    return Result<bool>.Failure("Project already exists");
            try
            {
                if (_projectRepo.IsProjectExistByName(dto.Name))
                    throw new ArgumentException("Project already exists!");
                /*// The service layer maps the DTO data to a new Project domain entity
                Address newAddress = new Address(-1, dto.AddressCreate.ID_Country, dto.AddressCreate.ID_City, dto.AddressCreate.APC, dto.AddressCreate.Street, dto.AddressCreate.PostalCode, dto.AddressCreate.PlaceName, dto.AddressCreate.Landmark);
                //The validation is done implicitly in the creation constructor
                Project newProject = new Project(dto.Name, dto.ProjectCode, dto.StartDate, dto.Duration, dto.ProjectType, dto.Description, dto.LandRegistry, dto.SubdivisionPermitNumber, dto.SubdivisionPermitDate, dto.ConstructionPermitNumber, dto.ConstructionPermitDate, dto.DeedVolume, dto.DeedNumber, dto.DeedFolio, dto.LandBook, dto.LandBookDate, dto.LandBookBy, dto.IsSpecComplete, dto.Progress, dto.CreatedBy); */
                // Map DTO to domain objects
                var (project, address) = ProjectMapper.CreateDtoToDomain(dto);
                // The repository handles persisting the new domain entity to the database
                return await _projectRepo.SaveProjectWithAddressAsync(project, address);
            }
            catch (InvalidOperationException ex)
            {
                //TODO: _logger.LogError(ex, "Failed to create project");
                throw new InvalidOperationException(ex.Message);
            }
            catch (Exception ex)
            {
                throw ;
            }
        }
        // done
        public async Task<bool> UpdateAsync(ProjectUpdateDTO dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            Project existing = await _projectRepo.GetByID(dto.ID);
            if (existing == null)
                throw new Exception("Project not found!");

            var existingAddress = await _addressRepo.GetById(existing.Address_ID);
            if (existingAddress == null)
                throw new Exception("Address for this project not found!");
            //TODO: should make a transaction here
            existingAddress.Update(dto.AddressUpdate.ID_Country, dto.AddressUpdate.ID_City, dto.AddressUpdate.APC, dto.AddressUpdate.Street, dto.AddressUpdate.PostalCode, dto.AddressUpdate.PlaceName, dto.AddressUpdate.Landmark);
            if (!(await _addressRepo.UpdateAsync(existingAddress)))
                throw new Exception("Address Failed to update!");
            //existing.UpdateAddress(newAddress); TODO: will use this one
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
                dto.IsSpecComplete,
                dto.Progress,
                existingAddress.ID // Address ID
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
                var address = await _addressRepo.GetById(project.Address_ID);
                if (address == null)
                {
                    throw new InvalidOperationException($"address for project {project.Name} not found.");
                }
                return ProjectMapper.DomainToDtoWithAddress(project, address);
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
                var addresses = await _addressRepo.FindAllAsync();
                return ProjectMapper.DomainsToDtoList(projects, addresses);
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
                var allProjects = await _projectRepo.FindAll();
                var allAddresses = await _addressRepo.FindAllAsync();
                var allProjectsDTO = ProjectMapper.DomainsToDtoList(allProjects, allAddresses);
                return allProjectsDTO;
            }

            string normalizedSearchTerm = searchTerm.Trim().ToLowerInvariant();
            var projects = await _projectRepo.FindAll();
            var addresses = await _addressRepo.FindAllAsync();
            var AllProjectsDTO = ProjectMapper.DomainsToDtoList(projects, addresses);
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
        public async Task<IEnumerable<ProjectMinDTO>> GetAllMinAsync()
        {
            try
            {
                IEnumerable<Project> projects = await _projectRepo.FindAllFullAsync();

                return projects.Select(p => ProjectMapper.DomainsToMinDto(p));
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<ProjectMinDTO>();
            }
        }

        //******************************* Mock Data *****************************
        public List<ProjectMinDTO> GetMockProjects()
        {
            return new List<ProjectMinDTO>
        {
            new ProjectMinDTO(1, "E-Commerce Website", false),
            new ProjectMinDTO(2, "Mobile Banking App", false),
            new ProjectMinDTO(3, "Inventory Management System", false),
            new ProjectMinDTO(4, "Customer Relationship Management", false),
            new ProjectMinDTO(5, "Analytics Dashboard", false),
            new ProjectMinDTO(6, "IoT Smart Home System", false),
            new ProjectMinDTO(7, "Learning Management Platform", false),
            new ProjectMinDTO(8, "Healthcare Patient Portal", false),
            new ProjectMinDTO(9, "Real Estate Listing Service", false),
            new ProjectMinDTO(10, "Social Media Analytics Tool", false)
        };
        }
    }
}
