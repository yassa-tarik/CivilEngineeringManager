using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Abstractions
{
    public interface ICountryRepository
    {
        List<Country> GetAll();
    }
}
