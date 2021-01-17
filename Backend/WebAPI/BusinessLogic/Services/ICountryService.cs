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
        Task<IReadOnlyCollection<Country>> GetAllAsync();
        Task<Country> GetAsync(int id);
        Task<int> AddAsync(Country country);
        Task<CountryEntity> UpdateAsync(Country country);
    }
}