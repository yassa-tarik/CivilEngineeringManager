using BLL.Domain;
using DAL.Contracts.SubcontractorEntity;
using DTO.Address;
using DTO.Contact;
using DTO.Subcontractor;
using System;

namespace BLL.Mappers.Subcontractors
{
    internal static class SubcontractorMapper
    {
        internal static Subcontractor ToDomain(SubcontractorEntityDTO entityDto)
        {
            var addressDTO = new AddressDTO(entityDto.ID_Address, entityDto.ID_Country, entityDto.ID_City, entityDto.APC, entityDto.Address, entityDto.PostalCode, entityDto.LieuDit, entityDto.Reper);
            var contactDTO = new ContactDTO(entityDto.ID_Contact, entityDto.ID_Address, entityDto.Telephone, entityDto.Mobile, entityDto.Telecopie, entityDto.Email, addressDTO);  

            return new Subcontractor(entityDto.ID, entityDto.ID_Contact, entityDto.RaisonSocial, entityDto.Representant, entityDto.NumCptBank, entityDto.CreationDate, entityDto.CreePar, entityDto.ModificationDate, entityDto.ModifierPar, entityDto.IsActive, contactDTO);
        }
        internal static SubcontractorEntityDTO ToEntityDTO(Subcontractor domain)
        {            
            return new SubcontractorEntityDTO(domain.ID, domain.ID_Contact, domain.RaisonSocial, domain.Representant, domain.NumCptBank, domain.CreationDate, domain.CreePar, domain.ModificationDate, domain.ModifierPar, domain.IsActive, domain.Contact.ID_Address, domain.Contact.Telephone, domain.Contact.Mobile, domain.Contact.Telecopie, domain.Contact.Email, domain.Contact.Address.ID_Country, domain.Contact.Address.ID_City, domain.Contact.Address.APC, domain.Contact.Address.Street, domain.Contact.Address.PostalCode, domain.Contact.Address.LieuDit, domain.Contact.Address.Reper);
        }
        internal static SubcontractorDTO ToDTO(Subcontractor domain)
        {
            return new SubcontractorDTO (domain.ID, domain.ID_Contact, domain.RaisonSocial, domain.Representant, domain.NumCptBank, domain.CreationDate, domain.CreePar, domain.ModificationDate, domain.ModifierPar, domain.IsActive, domain.Contact);
        }
    }
}
