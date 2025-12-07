using DTO.Countries;
using System.Collections.Generic;

namespace MyApplication.Abstractions
{
    public interface ICountryService
    {
        List<CountryDTO> GetAll();
    }
}
