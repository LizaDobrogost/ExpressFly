using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.Models;
using BlCountry = BusinessLogic.Models.Country;

namespace WebApi
{
    public static class WebApiMapping
    {
        public static void Initialize(IMapperConfigurationExpression config)
        {
            config.CreateMap<Country, BlCountry>();
            config.CreateMap<BlCountry, Country>();
        }
    }
}