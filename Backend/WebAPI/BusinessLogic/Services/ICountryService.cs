using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;

namespace BusinessLogic.Services
{
    public interface ICountryService
    {
        Task<IReadOnlyCollection<Country>> GetAllAsync();
        Task<Country> GetByIdAsync(int id);
        Task<Country> AddAsync(Country country);
        Task<Country> UpdateAsync(Country country);
    }
}