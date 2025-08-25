using BLL.Domain.Projects;
using BLL.Mappers.Addesses;
using DAL.Contract.Address;
using DAL.Contract.Project;
using DTO.Project;
using System;

namespace BLL.Mappers.Projects
{
    internal class ProjectMapper
    {
        // TODO: replace AddressEntityDTO mapping with plain propeties
        internal static Project EntityToDomain(DAL.Contract.Project.ProjectEntityDTO entityDto, AddressEntityDTO addressEntityDTO)
        {
            return new Project(
                entityDto.ID,
                entityDto.Name,
                entityDto.ProjectCode,
                entityDto.IsDeleted,
                entityDto.StartDate,
                entityDto.Duration,
                entityDto.ProjectType,
                entityDto.Description,
                entityDto.Progression,
                entityDto.IsActive,
                entityDto.CreatedBy,
                entityDto.LandRegistry,
                entityDto.SubdivisionPermitNumber,
                entityDto.SubdivisionPermitDate,
                entityDto.ConstructionPermitNumber,
                entityDto.ConstructionPermitDate,
                entityDto.DeedVolume,
                entityDto.DeedNumber,
                entityDto.DeedFolio,
                entityDto.LandBook,
                entityDto.LandBookDate,
                entityDto.LandBookBy,
                entityDto.IsSpecComplete,
                entityDto.Progress,
                AddressMapper.EntityToDomain(addressEntityDTO)
            );
        }
        internal static DAL.Contract.Project.ProjectEntityDTO DomainToEntityDTO(Project domain)
        {
            if (domain == null)
                throw new ArgumentNullException(nameof(domain));

            return new DAL.Contract.Project.ProjectEntityDTO(
                domain.ID,
                domain.Address?.ID ?? 0,
                domain.Name,
                domain.ProjectCode,
                domain.IsDeleted,
                domain.StartDate,
                domain.Duration,
                domain.ProjectType,
                domain.Description,
                domain.Progression,
                domain.IsActive,
                domain.CreatedBy,
                domain.LandRegistry,
                domain.SubdivisionPermitNumber,
                domain.SubdivisionPermitDate,
                domain.ConstructionPermitNumber,
                domain.ConstructionPermitDate,
                domain.DeedVolume,
                domain.DeedNumber,
                domain.DeedFolio,
                domain.LandBook,
                domain.LandBookDate,
                domain.LandBookBy,
                domain.IsSpecComplete,
                domain.Progress,
                domain.Address.ID_Country,
                domain.Address.ID_City,
                domain.Address.APC,
                domain.Address.Street,
                domain.Address.PostalCode,
                domain.Address.PlaceName,
                domain.Address.Landmark
            );
        }
        internal static DTO.Project.ProjectDTO DomainToDTO(Project domain)
        {
            if (domain == null)
                throw new ArgumentNullException(nameof(domain));

            return new DTO.Project.ProjectDTO(
                domain.ID,
                domain.Name,
                domain.ProjectCode,
                domain.IsDeleted,
                domain.StartDate,
                domain.Duration,
                domain.ProjectType,
                domain.Description,
                domain.Progression,
                domain.IsActive,
                domain.CreatedBy,
                domain.LandRegistry,
                domain.SubdivisionPermitNumber,
                domain.SubdivisionPermitDate,
                domain.ConstructionPermitNumber,
                domain.ConstructionPermitDate,
                domain.DeedVolume,
                domain.DeedNumber,
                domain.DeedFolio,
                domain.LandBook,
                domain.LandBookDate,
                domain.LandBookBy,
                domain.IsSpecComplete,
                domain.Progress,
                AddressMapper.DomainToDto(domain.Address)
            );
        }
        internal static DTO.Project.ProjectDTO EntityToDTO(DAL.Contract.Project.ProjectEntityDTO entity)
        {
            if (entity == null) return null;

            return new DTO.Project.ProjectDTO(
                entity.ID,
                entity.Name,
                entity.ProjectCode,
                entity.IsDeleted,
                entity.StartDate,
                entity.Duration,
                entity.ProjectType,
                entity.Description,
                entity.Progression,
                entity.IsActive,
                entity.CreatedBy,
                entity.LandRegistry,
                entity.SubdivisionPermitNumber,
                entity.SubdivisionPermitDate,
                entity.ConstructionPermitNumber,
                entity.ConstructionPermitDate,
                entity.DeedVolume,
                entity.DeedNumber,
                entity.DeedFolio,
                entity.LandBook,
                entity.LandBookDate,
                entity.LandBookBy,
                entity.IsSpecComplete,
                entity.Progress,
                AddressMapper.EntityToDTO(
                    entity.AddressID,
                    entity.CountryID,
                    entity.CityID,
                    entity.APC,
                    entity.Street,
                    entity.PostalCode,
                    entity.PlaceName,
                    entity.Landmark
                )
            );
        }
    }
}
