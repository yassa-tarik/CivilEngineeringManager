using Domain.Abstractions;
using DTO.Cities;
using MyApplication.Abstractions;
using System.Collections.Generic;
using System.Linq;

namespace MyApplication.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepo;
        private static readonly Dictionary<int, List<CityDTO>> _cachedCities = new Dictionary<int, List<CityDTO>>();

        public CityService(ICityRepository cityRepo)
        {
            _cityRepo = cityRepo;
        }

        public List<CityDTO> GetByCountryId(int countryId)
        {
            if (!_cachedCities.ContainsKey(countryId))
            {
                var entities = _cityRepo.GetByCountryId(countryId);
                var cityDtos = entities.Select(e => new CityDTO(e.ID, e.Country_ID, e.Name)).ToList();
                _cachedCities[countryId] = cityDtos;
            }

            return _cachedCities[countryId];
        }
    }
}