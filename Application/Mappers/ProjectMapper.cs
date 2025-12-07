using Domain.Entities;
using DTO.Projects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyApplication.Mappers
{
    internal static class ProjectMapper
    {
        public static ProjectDTO DomainToDto(Project project)
        {
            if (project == null)
                return null;

            var addressDTO = AddressMapper.DomainToDTO(project.Address);
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
                project.IsDeleted
            );
        }
        public static IEnumerable<ProjectDTO> DomainsToDtoList(IEnumerable<Project> projects)
        {
            //var addressMap = addresses.ToDictionary(a => a.ID);
            //return projects.Select(p => DomainToDtoWithAddress(p, addressMap.FirstOrDefault(a => (a.Key == p.Address_ID)).Value));
            return projects.Select(p => DomainToDto(p));
        }

        public static ProjectMinDTO DomainsToMinDto(Project project)
        {
            if (project == null) return null;
            return new ProjectMinDTO
            (
                project.ID,
                project.Name,
                project.IsSpecCompleted,
                project.Progress,
                project.ProjectType
            );
        }

        public static Project CreateDtoToDomain(ProjectCreateDTO dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));
            var address = new Address(

                dto.AddressDto.Country_ID,
                dto.AddressDto.City_ID,
                dto.AddressDto.Municipality,
                dto.AddressDto.PostalCode,
                dto.AddressDto.PlaceName,
                dto.AddressDto.Landmark);

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
                dto.IsSpecCompleted,
                dto.Progress,
                address);

            return project;
        }
    }
}
