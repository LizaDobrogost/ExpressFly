using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess.Repositories
{
    public interface ICountryRepository
    {
        Task<IReadOnlyCollection<CountryEntity>> GetAllAsync();
        Task<CountryEntity> GetAsync(int id);
        Task<int> AddAsync(CountryEntity country);
        Task UpdateAsync(CountryEntity country);
        Task<bool> CheckDuplicateAsync(CountryEntity country);
    }
}