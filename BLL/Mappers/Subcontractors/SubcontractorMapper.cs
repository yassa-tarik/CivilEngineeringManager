using BLL.Domain;
using BLL.Domain.Addresses;
using BLL.Domain.Contacts;
using BLL.Mappers.Contacts;
using DAL.Contracts.SubcontractorEntity;
using DTO.Subcontractor;

namespace BLL.Mappers.Subcontractors
{
    internal static class SubcontractorMapper
    {
        internal static Subcontractor EntityToDomain(SubcontractorEntityDTO entityDto)
        {
            var address = new Address(entityDto.ID_Address, entityDto.ID_Country, entityDto.ID_City, entityDto.APC, entityDto.Street, entityDto.PostalCode, entityDto.PlaceName, entityDto.Landmark);
            var contact = new Contact(entityDto.ID_Contact, entityDto.ID_Address, entityDto.Telephone, entityDto.Mobile, entityDto.Fax, entityDto.Email, address);

            return new Subcontractor(entityDto.ID, entityDto.ID_Contact, entityDto.CompanyName, entityDto.Representative, entityDto.BankAccountNumber, entityDto.CreationDate, entityDto.CreatedBy, entityDto.ModificationDate, entityDto.ModifiedBy, entityDto.IsActive, contact);
        }
        internal static SubcontractorEntityDTO DomainToEntityDTO(Subcontractor domain)
        {
            return new SubcontractorEntityDTO(domain.ID, domain.ID_Contact, domain.CompanyName, domain.Representative, domain.BankAccountNumber, domain.CreationDate, domain.CreatedBy, domain.ModificationDate, domain.ModifiedBy, domain.IsActive, domain.Contact.ID_Address, domain.Contact.Telephone, domain.Contact.Mobile, domain.Contact.Fax, domain.Contact.Email, domain.Contact.Address.ID_Country, domain.Contact.Address.ID_City, domain.Contact.Address.APC, domain.Contact.Address.Street, domain.Contact.Address.PostalCode, domain.Contact.Address.PlaceName, domain.Contact.Address.Landmark);
        }
        internal static SubcontractorDTO EntityToDTO(SubcontractorEntityDTO entity)
        {
            if (entity == null) return null;
            // Map the Contact fields into a ContactDTO using ContactMapper
            var contactDto = ContactMapper.EntityToDTO(entity.ID_Contact, entity.ID_Address, entity.Telephone, entity.Mobile, entity.Fax, entity.Email, entity.ID_Country, entity.ID_City, entity.APC, entity.Street, entity.PostalCode, entity.PlaceName, entity.Landmark);
            return new SubcontractorDTO(entity.ID, entity.ID_Contact, entity.CompanyName, entity.Representative, entity.BankAccountNumber, entity.CreationDate, entity.CreatedBy, entity.ModificationDate, entity.ModifiedBy, entity.IsActive, contactDto);
        }

        internal static Subcontractor DTOToDomain(SubcontractorDTO dto)
        {
            if (dto == null) return null;
            var contactDomain = ContactMapper.DTOToDomain(dto.Contact);

            return new Subcontractor(dto.ID, dto.ID_Contact, dto.CompanyName, dto.Representative, dto.BankAccountNumber, dto.CreationDate, dto.CreatedBy, dto.ModificationDate, dto.ModifiedBy, dto.IsActive, contactDomain);
        }
    }
}
