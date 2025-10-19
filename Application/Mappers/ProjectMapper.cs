using Domain.Entities;
using DTO.Projects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyApplication.Mappers
{
    internal static class ProjectMapper
    {
        public static ProjectDTO DomainToDtoWithAddress(Project project, Address address)
        {
            if (project == null) throw new ArgumentNullException(nameof(project) + "not found!");
            if (address == null)
                throw new ArgumentNullException(nameof(address) + "not found");

            var addressDTO = AddressMapper.DomainToDTO(address);
            return new ProjectDTO
            (
                project.ID,
                project.Name,
                project.ProjectCode,
                project.StartDate,
                project.Duration,
                project.ProjectType,
                project.Description,
                project.IsActive,
                project.LandRegistry,
                project.SubdivisionPermitNumber,
                project.SubdivisionPermitDate,
                project.ConstructionPermitNumber,
                project.ConstructionPermitDate,
                project.DeedVolume,
                project.DeedNumber,
                project.DeedFolio,
                project.LandBook,
                project.LandBookDate,
                project.LandBookBy,
                project.IsSpecCompleted,
                project.Progress,
                addressDTO,
                project.CreationDate,
                project.CreatedBy,
                project.ModificationDate,
                project.ModifiedBy,
                project.IsDeleted
            );
        }
        public static IEnumerable<ProjectDTO> DomainsToDtoList(IEnumerable<Project> projects, IEnumerable<Address> addresses)
        {
            var addressMap = addresses.ToDictionary(a => a.ID);
            return projects.Select(p => DomainToDtoWithAddress(p, addressMap.FirstOrDefault(a => (a.Key == p.Address_ID)).Value));
        }

        public static ProjectMinDTO DomainsToMinDto(Project project)
        {
            if (project == null) throw new ArgumentNullException(nameof(project) + "not found!");
            return new ProjectMinDTO
            (
                project.ID,
                project.Name,
                project.IsSpecCompleted
            );
        }

        public static (Project project, Address address) CreateDtoToDomain( ProjectCreateDTO dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));
            var address = new Address(
                -1,
                dto.AddressCreate.ID_Country,
                dto.AddressCreate.ID_City,
                dto.AddressCreate.APC,
                dto.AddressCreate.Street,
                dto.AddressCreate.PostalCode,
                dto.AddressCreate.PlaceName,
                dto.AddressCreate.Landmark);

            var project = new Project(
                dto.Name,
                dto.ProjectCode,
                dto.StartDate,
                dto.Duration,
                dto.ProjectType,
                dto.Description,
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
                dto.Progress );

            return (project, address);
        }
    }
}
