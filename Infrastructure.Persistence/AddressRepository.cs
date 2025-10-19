using Domain.Abstractions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class AddressRepository : IAddressRepository
    {
        public Task<Address> AddAsync(Address address)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Address>> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Address> GetById(int addressId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Address>> SearchAsync(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Address address)
        {
            throw new NotImplementedException();
        }
    }
}
