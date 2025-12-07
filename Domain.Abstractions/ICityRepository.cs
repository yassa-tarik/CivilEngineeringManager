using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Abstractions
{
    public interface ICityRepository
    {
        List<City> GetAll();
        List<City> GetByCountryId(int countryId);
    }
}
