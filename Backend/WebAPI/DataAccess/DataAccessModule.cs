using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess
{
    public static class DataAccessModule
    {
        public static void Register(IServiceCollection services)
        {
            services.AddSingleton<ICountryRepository, CountryRepository>();
        }
    }
}