using DTO.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Abstractions
{
    public interface IAddressService
    {
        Task UpdateAsync(AddressUpdateDTO addressDto);
        Task<AddressDTO> AddNewAsync(AddressCreateDTO addressDto);
        Task<IEnumerable<AddressDTO>> SearchAddressesAsync(string searchTerm);
        Task<AddressDTO> GetAddressByIdAsync(int addressId);
        Task<IEnumerable<AddressDTO>> GetAllAddressesAsync();

    }
}
