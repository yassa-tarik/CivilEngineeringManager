using Domain.Abstractions;
using DTO.Countries;
using MyApplication.Abstractions;
using System.Collections.Generic;
using System.Linq;

namespace MyApplication.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepo;
        private static List<CountryDTO> _cachedCountries;

        public CountryService(ICountryRepository countryRepo)
        {
            _countryRepo = countryRepo;
        }

        public List<CountryDTO> GetAll()
        {
            if (_cachedCountries == null)
            {
                var domainCountries = _countryRepo.GetAll();
                _cachedCountries = domainCountries
                    .Select(c => new CountryDTO(c.Id, c.Name)
                    ).ToList();
            }

            return _cachedCountries;
        }
    }
}
