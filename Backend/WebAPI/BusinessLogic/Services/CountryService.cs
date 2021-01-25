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

        public async Task<int> AddAsync(CountryModel countryModel)
        {
            CountryEntity countryDal = _mapper.Map<CountryEntity>(countryModel);

            bool countryDuplicate = await _countryRepository.CheckDuplicateAsync(countryDal);

            if (countryDuplicate)
            {
                throw new Exception("This country already exists");
            }

            int addedCountryId = await _countryRepository.AddAsync(countryDal);

            return addedCountryId;
        }

        public async Task<CountryEntity> UpdateAsync(CountryModel countryModel)
        {
            CountryEntity oldCountryDal = await _countryRepository.GetAsync(countryModel.Id);

            if (oldCountryDal == null)
            {
                return null;
            }

            CountryEntity countryDal = _mapper.Map<CountryEntity>(countryModel);

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