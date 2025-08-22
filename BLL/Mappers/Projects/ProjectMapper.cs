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
        internal static Project EntityToDomain(ProjectEntityDTO entityDto, AddressEntityDTO addressEntityDTO)
        {
            return new Project(entityDto.ID, entityDto.Nom, entityDto.CodeProjet, entityDto.isDeleted, entityDto.DateDebut, entityDto.Duree, entityDto.TypeProjet, entityDto.Description, entityDto.Avancement, entityDto.IsActive, entityDto.CreePar, entityDto.ConcervationFonciere, entityDto.PermisDeLotirNum, entityDto.PermisDeLotirDu, entityDto.PermisDeConstNum, entityDto.PermisDeConstDu, entityDto.ActeVolume, entityDto.ActeNum, entityDto.ActeFolio, entityDto.LivretFoncier, entityDto.LivretFoncierLe, entityDto.LivretFoncierPar, entityDto.isSpecComplete, entityDto.Progress, AddressMapper.EntityToDomain(addressEntityDTO));

        }
        internal static ProjectEntityDTO DomainToEntityDTO(Project domain)
        {
            if (domain == null)
                throw new ArgumentNullException(nameof(domain));

            return new ProjectEntityDTO(domain.ID, domain.Address?.ID ?? 0, domain.Nom, domain.CodeProjet, domain.isDeleted, domain.DateDebut, domain.Duree, domain.TypeProjet, domain.Description, domain.Avancement, domain.IsActive, domain.CreePar, domain.ConcervationFonciere, domain.PermisDeLotirNum, domain.PermisDeLotirDu, domain.PermisDeConstNum, domain.PermisDeConstDu, domain.ActeVolume, domain.ActeNum, domain.ActeFolio, domain.LivretFoncier, domain.LivretFoncierLe, domain.LivretFoncierPar, domain.isSpecComplete, domain.Progress, domain.Address.ID_Country, domain.Address.ID_City, domain.Address.APC, domain.Address.Street, domain.Address.PostalCode, domain.Address.LieuDit, domain.Address.Reper);
        }
        internal static ProjectDTO DomainToDTO(Project domain)
        {
            if (domain == null)
                throw new ArgumentNullException(nameof(domain));

            return new ProjectDTO(domain.ID, domain.Nom, domain.CodeProjet, domain.isDeleted, domain.DateDebut, domain.Duree, domain.TypeProjet, domain.Description, domain.Avancement, domain.IsActive, domain.CreePar, domain.ConcervationFonciere, domain.PermisDeLotirNum, domain.PermisDeLotirDu, domain.PermisDeConstNum, domain.PermisDeConstDu, domain.ActeVolume, domain.ActeNum, domain.ActeFolio, domain.LivretFoncier, domain.LivretFoncierLe, domain.LivretFoncierPar, domain.isSpecComplete, domain.Progress, AddressMapper.DomainToDto(domain.Address));
        }
        internal static ProjectDTO EntityToDTO(ProjectEntityDTO entity)
        {
            if (entity == null) return null;

            return new ProjectDTO(entity.ID, entity.Nom, entity.CodeProjet, entity.isDeleted, entity.DateDebut, entity.Duree, entity.TypeProjet, entity.Description, entity.Avancement,
                entity.IsActive, entity.CreePar, entity.ConcervationFonciere,
                entity.PermisDeLotirNum, entity.PermisDeLotirDu, entity.PermisDeConstNum,
                entity.PermisDeConstDu, entity.ActeVolume, entity.ActeNum,
                entity.ActeFolio, entity.LivretFoncier, entity.LivretFoncierLe,
                entity.LivretFoncierPar, entity.isSpecComplete, entity.Progress,
                AddressMapper.EntityToDTO(entity.ID_Adresse, entity.ID_Country, entity.ID_City, entity.APC, entity.Street, entity.PostalCode, entity.LieuDit, entity.Reper));
        }
    }
}
