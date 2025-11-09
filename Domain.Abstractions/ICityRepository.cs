using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions
{
    public interface ICityRepository
    {
        List<City> GetAll();
        List<City> GetByCountryId(int countryId);
    }
}
