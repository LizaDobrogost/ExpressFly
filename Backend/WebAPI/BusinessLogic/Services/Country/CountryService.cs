using System;
using System.Collections.Generic;
using System.IO;
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

        public async Task<IReadOnlyCollection<CountryModel>> GetAsync() 
        {
            IReadOnlyCollection<CountryEntity> countriesEntities = await _countryRepository.GetAllAsync();
            
            IReadOnlyCollection<CountryModel> countries = countriesEntities.Select( _mapper.Map<CountryModel>).ToList();

            return countries;
        }

        public async Task<CountryModel> GetAsync(int id)
        {
            CountryEntity foundCountryEntity = await _countryRepository.GetAsync(id);

            return _mapper.Map<CountryModel>(foundCountryEntity);
        }

        public async Task<CountryModel> AddAsync(CountryModel countryModel)
        {
            CountryEntity country = _mapper.Map<CountryEntity>(countryModel);

            bool countryDuplicate = await _countryRepository.CheckDuplicateAsync(country);

            if (countryDuplicate)
            {
                throw new InvalidDataException("This country already exists");
            }

            await _countryRepository.AddAsync(country);

            return countryModel;
        }

        public async Task<CountryModel> UpdateAsync(CountryModel countryModel)
        {
            CountryEntity countryEntity = await _countryRepository.GetAsync(countryModel.Id);

            if (countryEntity == null)
            {
                throw new InvalidDataException("Country not found");
            }

            CountryEntity country = _mapper.Map<CountryEntity>(countryModel);

            bool duplicate = await _countryRepository.CheckDuplicateAsync(country);

            if (duplicate)
            {
                throw new InvalidDataException("This country already exists");
            }

            await _countryRepository.UpdateAsync(country);

            return countryModel;
        }
    }
}