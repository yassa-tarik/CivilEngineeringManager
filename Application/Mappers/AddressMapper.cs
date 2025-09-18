using Domain.Entities;
using DTO.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Mappers
{
    internal static class AddressMapper
    {
        public static AddressDTO DomainToDTO(Address domain)
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
    }
}
