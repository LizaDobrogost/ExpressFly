using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using WebApi.Models;

namespace DataAccess.Repositories
{
    class CountryRepository : ICountryRepository
    {
        private readonly IConnectionSettings _connectionSettings;

        public CountryRepository(IConnectionSettings settings)
        {
            _connectionSettings = settings;
        }

        public async Task<IReadOnlyCollection<Country>> GetAllAsync()
        {
            await using SqlConnection db = new SqlConnection(_connectionSettings.ConnectionString);

            IEnumerable<Country> countries = await db.QueryAsync<Country>(
                "GetAllCountries",
                null,
                commandType: CommandType.StoredProcedure);

            return countries.ToList();
        }

        public async Task<Country> GetAsync(int id)
        {
            await using SqlConnection db = new SqlConnection(_connectionSettings.ConnectionString);

            return await db.QuerySingleOrDefaultAsync<Country>(
                "GetCountryById",
                new {id},
                commandType: CommandType.StoredProcedure);
        }

        public async Task<Country> AddAsync(Country country)
        {
            await using SqlConnection db = new SqlConnection(_connectionSettings.ConnectionString);

            return await db.QuerySingleOrDefaultAsync<Country>(
                "AddCountry",
                new {name = country.Name},
                commandType: CommandType.StoredProcedure);
        }

        public async Task<Country> UpdateAsync(Country country)
        {
            await using SqlConnection db = new SqlConnection(_connectionSettings.ConnectionString);

            return await db.QuerySingleOrDefaultAsync<Country>(
                "UpdateCountry",
                country,
                commandType: CommandType.StoredProcedure);
        }
    }
}