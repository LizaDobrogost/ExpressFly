using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Repositories;
using WebApi.Models;

namespace BusinessLogic.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<IReadOnlyCollection<Country>> GetAllAsync()
        {
            IReadOnlyCollection<Country> countriesDal = await _countryRepository.GetAllAsync();
            return countriesDal;
        }

        public async Task<Country> GetByIdAsync(int id)
        {
            Country foundCountryDal = await _countryRepository.GetAsync(id);

            return foundCountryDal;
        }

        public async Task<Country> AddAsync(Country country)
        {
            Country addedCountryId = await _countryRepository.AddAsync(country);

            return addedCountryId;
        }

        public async Task<Country> UpdateAsync(Country country)
        {
            Country oldCountryDal = await _countryRepository.GetAsync(country.Id);

            Country cont= await _countryRepository.UpdateAsync(oldCountryDal);

            return cont;
        }
    }
}