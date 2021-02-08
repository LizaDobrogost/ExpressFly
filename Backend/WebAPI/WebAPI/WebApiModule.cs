using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using WebApi.JWT;

namespace WebApi
{
    public static class WebApiModule
    {
        public static void Register(IServiceCollection services)
        {
            services.AddTransient<IJwtService, JwtService>();
        }
    }
}
