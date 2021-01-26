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
        Task<Response> AddAsync(CountryModel countryModel);
        Task<ResultTypes> UpdateAsync(CountryModel countryModel);
    }
}