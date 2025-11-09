using Domain.Abstractions;
using MyApplication.Abstractions;
using System.Collections.Generic;
using System.Linq;
using DTO.Cities;

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

        //public List<CityDTO> GetAll()
        //{
        //    if (_cachedCities == null)
        //    {
        //        var domainCities = _cityRepo.GetAll();
        //        _cachedCities = domainCities
        //            .Select(c => new CityDTO
        //            (
        //                c.Id,
        //                c.Name,
        //                c.CountryId
        //            ))
        //            .ToList();
        //    }

        //    return _cachedCities;
        //}

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
