using DTO.Cities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Abstractions
{
    public interface ICityService
    {
        List<CityDTO> GetByCountryId(int countryId);
    }
}
