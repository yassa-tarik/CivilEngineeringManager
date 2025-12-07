using DTO.Cities;
using System.Collections.Generic;

namespace MyApplication.Abstractions
{
    public interface ICityService
    {
        List<CityDTO> GetByCountryId(int countryId);
    }
}
