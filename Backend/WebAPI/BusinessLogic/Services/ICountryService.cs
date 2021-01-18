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
        Task<IReadOnlyCollection<CountryBusinessModel>> GetAllAsync();
        Task<CountryBusinessModel> GetAsync(int id);
        Task<int> AddAsync(CountryBusinessModel countryBusinessModel);
        Task<CountryEntity> UpdateAsync(CountryBusinessModel countryBusinessModel);
    }
}