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
        Task<IReadOnlyCollection<CountryModel>> GetAsync();
        Task<CountryModel> GetAsync(int id);
        Task<CountryModel> AddAsync(CountryModel countryModel);
        Task<CountryModel> UpdateAsync(CountryModel countryModel);
    }
}