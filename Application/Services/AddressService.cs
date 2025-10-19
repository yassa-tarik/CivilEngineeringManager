using Domain.Abstractions;
using DTO.Addresses;
using MyApplication.Abstractions;
using MyApplication.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApplication.Services
{
    /// <summary>
    /// Handles business logic for Address-related operations.
    /// </summary>
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        /// <summary>
        /// Retrieves all addresses.
        /// </summary>
        public async Task<IEnumerable<AddressDTO>> GetAllAddressesAsync()
        {
            var addresses = await _addressRepository.FindAllAsync();
            return addresses.Select(a => AddressMapper.DomainToDTO(a));
        }

        /// <summary>
        /// Retrieves a single address by its ID.
        /// </summary>
        public async Task<AddressDTO> GetAddressByIdAsync(int addressId)
        {
            throw new NotImplementedException();
            //var address = await _addressRepository.FindById(addressId);
            //return AddressMapper.ToDto(address);
        }

        /// <summary>
        /// Searches for addresses based on a search term.
        /// </summary>
        public async Task<IEnumerable<AddressDTO>> SearchAddressesAsync(string searchTerm)
        {
            throw new NotImplementedException();
            //var addresses = await _addressRepository.SearchAsync(searchTerm);
            //return AddressMapper.ToDtoList(addresses);
        }

        /// <summary>
        /// Adds a new address to the repository.
        /// </summary>
        public async Task<AddressDTO> AddNewAsync(AddressCreateDTO addressDto)
        {
            throw new NotImplementedException();
            //var newAddress = AddressMapper.ToDomain(addressDto);
            //var addedAddress = await _addressRepository.AddAsync(newAddress);
            //return AddressMapper.ToDto(addedAddress);
        }

        /// <summary>
        /// Updates an existing address.
        /// </summary>
        public async Task UpdateAsync(AddressUpdateDTO addressDto)
        {
            throw new NotImplementedException();
            //var addressToUpdate = AddressMapper.ToDomain(addressDto);
            //await _addressRepository.UpdateAsync(addressToUpdate);
        }
    }
}
