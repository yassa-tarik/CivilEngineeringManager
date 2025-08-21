using BLL.Domain;
using BLL.Domain.Addresses;
using BLL.Domain.Contacts;
using BLL.Mappers.Contacts;
using DAL.Contracts.SubcontractorEntity;
using DTO.Address;
using DTO.Contact;
using DTO.Subcontractor;
using System;

namespace BLL.Mappers.Subcontractors
{
    internal static class SubcontractorMapper
    {
        internal static Subcontractor EntityToDomain(SubcontractorEntityDTO entityDto)
        {
            var address = new Address(entityDto.ID_Address, entityDto.ID_Country, entityDto.ID_City, entityDto.APC, entityDto.Street, entityDto.PostalCode, entityDto.LieuDit, entityDto.Reper);
            var contact = new Contact(entityDto.ID_Contact, entityDto.ID_Address, entityDto.Telephone, entityDto.Mobile, entityDto.Telecopie, entityDto.Email, address);  

            return new Subcontractor(entityDto.ID, entityDto.ID_Contact, entityDto.RaisonSocial, entityDto.Representant, entityDto.NumCptBank, entityDto.CreationDate, entityDto.CreePar, entityDto.ModificationDate, entityDto.ModifierPar, entityDto.IsActive, contact);
        }
        internal static SubcontractorEntityDTO DomainToEntityDTO(Subcontractor domain)
        {            
            return new SubcontractorEntityDTO(domain.ID, domain.ID_Contact, domain.RaisonSocial, domain.Representant, domain.NumCptBank, domain.CreationDate, domain.CreePar, domain.ModificationDate, domain.ModifierPar, domain.IsActive, domain.Contact.ID_Address, domain.Contact.Telephone, domain.Contact.Mobile, domain.Contact.Telecopie, domain.Contact.Email, domain.Contact.Address.ID_Country, domain.Contact.Address.ID_City, domain.Contact.Address.APC, domain.Contact.Address.Street, domain.Contact.Address.PostalCode, domain.Contact.Address.LieuDit, domain.Contact.Address.Reper);
        }
        //internal static SubcontractorDTO DomainToDTO(Subcontractor domain)
        //{
        //    return new SubcontractorDTO (domain.ID, domain.ID_Contact, domain.RaisonSocial, domain.Representant, domain.NumCptBank, domain.CreationDate, domain.CreePar, domain.ModificationDate, domain.ModifierPar, domain.IsActive, domain.Contact);
        //}

        //------------------------
        internal static SubcontractorDTO EntityToDTO(SubcontractorEntityDTO entity)
        {
            if (entity == null) return null;
            // Map the Contact fields into a ContactDTO using ContactMapper
            var contactDto = ContactMapper.EntityToDTO(entity.ID_Contact,entity.ID_Address,entity.Telephone,entity.Mobile, entity.Telecopie,entity.Email,entity.ID_Country,entity.ID_City,entity.APC,entity.Street,entity.PostalCode,entity.LieuDit,entity.Reper);
            return new SubcontractorDTO     ( entity.ID,entity.ID_Contact,entity.RaisonSocial,entity.Representant,entity.NumCptBank,entity.CreationDate,entity.CreePar,entity.ModificationDate,entity.ModifierPar,entity.IsActive,contactDto);
        }

        internal static Subcontractor DTOToDomain(SubcontractorDTO dto)
        {
            if (dto == null) return null;
            var contactDomain = ContactMapper.DTOToDomain(dto.Contact);

            return new Subcontractor(dto.ID,dto.ID_Contact,dto.RaisonSocial,dto.Representant,dto.NumCptBank,dto.CreationDate,dto.CreePar,dto.ModificationDate,dto.ModifierPar,dto.IsActive,contactDomain);
        }
    }
}
