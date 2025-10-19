using Domain.Entities;
using DTO.Addresses;

namespace MyApplication.Mappers
{
    internal static class AddressMapper
    {
        public static AddressDTO DomainToDTO(Address domain)
        {
            if (domain == null) return null;

            return new AddressDTO(
                domain.ID,
                domain.Country_ID,
                domain.City_ID,
                domain.Municipality,
                domain.Street,
                domain.PostalCode,
                domain.PlaceName,
                domain.Landmark
            );
        }
    }
}
