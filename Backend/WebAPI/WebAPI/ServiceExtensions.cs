﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi
{
    public static class ServiceExtensions
    {
        private const string AllowedSpecificOrigin = "SpecificCorsPolicy";
        public static void AddCorsPolicy(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            services.AddCors(
                options =>
                {
                    options.AddPolicy(
                        AllowedSpecificOrigin,
                        builder =>
                        {
                            builder
                                .WithOrigins(
                                    configuration.GetSection("AllowedOrigins")
                                        .Get<string[]>()
                                )
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                        }
                    );
                }
            );
        }
    }
}