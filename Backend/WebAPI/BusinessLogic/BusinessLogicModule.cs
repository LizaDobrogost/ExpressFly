using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogic
{
    public class BusinessLogicModule
    {
        public static void Register(IServiceCollection services)
        {
            services.AddSingleton<ICountryService, CountryService>();

            services.AddTransient<IAccountService, AccountService>();
        }
    }
}