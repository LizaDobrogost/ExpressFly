using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogic.Models;
using DataAccess.Entities;
using DataAccess.Repositories;

namespace BusinessLogic.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;


        public CountryService(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyCollection<Country>> GetAllAsync() 
        {
            IReadOnlyCollection<CountryEntity> countriesEntities = await _countryRepository.GetAllAsync();

            IReadOnlyCollection<Country> countries = countriesEntities.Select(_mapper.Map<Country>).ToList();

            return countries;
        }

        public async Task<Country> GetAsync(int id)
        {
            CountryEntity foundCountryEntity = await _countryRepository.GetAsync(id);

            return _mapper.Map<Country>(foundCountryEntity);
        }

        public async Task<int> AddAsync(Country country)
        {
            CountryEntity countryDal = _mapper.Map<CountryEntity>(country);

            bool countryDuplicate = await _countryRepository.CheckDuplicateAsync(countryDal);

            if (countryDuplicate)
            {
                return 0;
            }

            int addedCountryId = await _countryRepository.AddAsync(countryDal);

            return addedCountryId;
        }

        public async Task<CountryEntity> UpdateAsync(Country country)
        {
            CountryEntity oldCountryDal = await _countryRepository.GetAsync(country.Id);

            if (oldCountryDal == null)
            {
                return null;
            }

            CountryEntity countryDal = _mapper.Map<CountryEntity>(country);

            bool duplicate = await _countryRepository.CheckDuplicateAsync(countryDal);

            if (duplicate)
            {
                return null;
            }

            await _countryRepository.UpdateAsync(countryDal);

            return countryDal;
        }
    }
}