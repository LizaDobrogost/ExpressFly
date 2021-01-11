using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;

namespace DataAccess.Repositories
{
    public interface ICountryRepository
    {
        Task<IReadOnlyCollection<Country>> GetAllAsync();
        Task<Country> GetAsync(int id);
        Task<Country> AddAsync(Country country);
        Task<Country> UpdateAsync(Country country);
    }
}