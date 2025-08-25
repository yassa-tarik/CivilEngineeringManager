using BLL.Domain.Addresses;
using DAL.Contract.Address;
using DTO.Address;

namespace BLL.Mappers.Addesses
{
    internal class AddressMapper
    {
        // Domain <-> DTO
        public static AddressDTO DomainToDto(Address domain)
        {
            if (domain == null) return null;

            return new AddressDTO(
                domain.ID,
                domain.ID_Country,
                domain.ID_City,
                domain.APC,
                domain.Street,
                domain.PostalCode,
                domain.PlaceName,
                domain.Landmark
            );
        }

        public static Address DTOToDomain(AddressDTO dto)
        {
            if (dto == null) return null;

            return new Address(
                dto.ID,
                dto.ID_Country,
                dto.ID_City,
                dto.APC,
                dto.Street,
                dto.PostalCode,
                dto.PlaceName,
                dto.Landmark
            );
        }

        // DAL Entity <-> Domain
        public static Address EntityToDomain(AddressEntityDTO entity)
        {
            if (entity == null) return null;

            return new Address(
                entity.ID,
                entity.ID_Country,
                entity.ID_City,
                entity.APC,
                entity.Street,
                entity.PostalCode,
                entity.PlaceName,
                entity.Landmark
            );
        }

        public static AddressEntityDTO DomainToEntity(Address domain)
        {
            if (domain == null) return null;

            return new AddressEntityDTO(
                domain.ID,
                domain.ID_Country,
                domain.ID_City,
                domain.APC,
                domain.Street,
                domain.PostalCode,
                domain.PlaceName,
                domain.Landmark
            );
        }

        internal static AddressDTO EntityToDTO(int ID, int ID_Country, int ID_City, string APC, string Street, string PostalCode, string PlaceName, string Landmark)
        {
            return new AddressDTO(ID, ID_Country, ID_City, APC, Street, PostalCode, PlaceName, Landmark);
        }
    }
}
