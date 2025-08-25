using BLL.Domain.Contacts;
using BLL.Mappers.Addesses;
using DTO.Address;
using DTO.Contact;

namespace BLL.Mappers.Contacts
{
    internal class ContactMapper
    {
        public static Contact DTOToDomain(ContactDTO dto)
        {
            if (dto == null) return null;

            var addressDomain = AddressMapper.DTOToDomain(dto.Address);

            return new Contact(
                dto.ID,
                dto.ID_Address,
                dto.Telephone,
                dto.Mobile,
                dto.Fax,
                dto.Email,
                addressDomain
            );
        }

        public static ContactDTO EntityToDTO(int id, int id_Address, string telephone, string mobile, string fax, string email, int idCountry, int idCity, string apc, string street, string postalCode, string placeName, string landmark)
        {
            var addressDto = new AddressDTO(id_Address, idCountry, idCity, apc, street, postalCode, placeName, landmark);

            return new ContactDTO(id, id_Address, telephone, mobile, fax, email, addressDto);
        }
    }
}
