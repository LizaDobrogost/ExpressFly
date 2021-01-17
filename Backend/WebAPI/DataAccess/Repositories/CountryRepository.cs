using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DataAccess.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly IConfiguration _connectionSettings;

        public CountryRepository(IConfiguration settings)
        {
            _connectionSettings = settings;
        }

        public async Task<IReadOnlyCollection<CountryEntity>> GetAllAsync()
        {
            await using SqlConnection db = new SqlConnection(_connectionSettings.GetConnectionString("AirportDatabase"));

            IEnumerable<CountryEntity> countries = await db.QueryAsync<CountryEntity>(
                "GetAllCountries",
                null,
                commandType: CommandType.StoredProcedure);

            return countries.ToList();
        }

        public async Task<CountryEntity> GetAsync(int id)
        {
            await using SqlConnection
                db = new SqlConnection(_connectionSettings.GetConnectionString("AirportDatabase"));

            return await db.QuerySingleOrDefaultAsync<CountryEntity>(
                "GetCountryById",
                new {id},
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> AddAsync(CountryEntity country)
        {
            await using SqlConnection
                db = new SqlConnection(_connectionSettings.GetConnectionString("AirportDatabase"));

            return await db.QuerySingleOrDefaultAsync<int>(
                "AddCountry",
                new {name = country.Name},
                commandType: CommandType.StoredProcedure);
        }

        public async Task UpdateAsync(CountryEntity country)
        {
            using SqlConnection db = new SqlConnection(_connectionSettings.GetConnectionString("AirportDatabase"));

            await db.ExecuteAsync(
                "UpdateCountry",
                country,
                commandType: CommandType.StoredProcedure);
        }

        public async Task<bool> CheckDuplicateAsync(CountryEntity country)
        {
            using SqlConnection db = new SqlConnection(_connectionSettings.GetConnectionString("AirportDatabase"));

            return await db.ExecuteScalarAsync<bool>(
                "CheckCountryDuplicate",
                new {name = country.Name},
                commandType: CommandType.StoredProcedure);
        }
    }
}