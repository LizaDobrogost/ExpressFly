using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Models;
using DataAccess.Entities;

namespace BusinessLogic.Services
{
    public interface ICountryService
    {
        Task<IReadOnlyCollection<CountryModel>> GetAllAsync();
        Task<CountryModel> GetAsync(int id);
        Task<int> AddAsync(CountryModel countryModel);
        Task<CountryEntity> UpdateAsync(CountryModel countryModel);
    }
}