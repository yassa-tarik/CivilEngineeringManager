using Domain.Entities;
using DTO.Addresses;

namespace MyApplication.Mappers
{
    internal static class AddressMapper
    {
        public static Address DTOToDomain(AddressDTO dto)
        {
            if (dto == null) return null;

            return new Address(
                dto.Country_ID,
                dto.City_ID,
                dto.Municipality,
                dto.PostalCode,
                dto.PlaceName,
                dto.Landmark
            );
        }

        public static AddressDTO DomainToDTO(Address domain)
        {
            if (domain == null) return null;

            return new AddressDTO(
                domain.Country_ID,
                domain.City_ID,
                domain.Municipality,
                domain.PostalCode,
                domain.PlaceName,
                domain.Landmark
            );
        }
    }
}
