using Domain.Entities;
using DTO.Addresses;
using DTO.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                project.IsSpecComplete,
                project.Progress,
                addressDTO,
                project.CreatedDate,
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
    }
}
