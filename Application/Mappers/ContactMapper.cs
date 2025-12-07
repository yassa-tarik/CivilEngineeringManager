using Domain.Entities;
using DTO.Contacts;

namespace MyApplication.Mappers
{
    public class ContactMapper
    {
        public static Contact DTOToDomain(ContactDTO dto)
        {
            if (dto == null) return null;

            return new Contact(
                dto.Telephone,
                dto.Mobile,
                dto.Telecopy,
                dto.Email,
                AddressMapper.DTOToDomain(dto.Address)
            );
        }

        public static ContactDTO DomainToDTO(Contact domain)
        {
            if (domain == null) return null;

            return new ContactDTO(
                domain.Telephone,
                domain.Mobile,
                domain.Telecopy,
                domain.Email,
                AddressMapper.DomainToDTO(domain.Address)
            );
        }
    }
}
