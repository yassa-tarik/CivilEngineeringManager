using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions
{
    public interface IAddressRepository
    {
        Task<Address> AddAsync(Address address);
        Task<bool> UpdateAsync(Address address);
        Task<Address> GetById(int addressId);
        Task<IEnumerable<Address>> FindAllAsync();
        Task<IEnumerable<Address>> SearchAsync(string searchTerm);
    }
}
