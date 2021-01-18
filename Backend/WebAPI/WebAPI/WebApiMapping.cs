using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogic.Models;
using WebApi.Models;

namespace WebApi
{
    public static class WebApiMapping
    {
        public static void Initialize(IMapperConfigurationExpression config)
        {
            config.CreateMap<CountryModel, CountryBusinessModel>();
            config.CreateMap<CountryBusinessModel, CountryModel>();
        }
    }
}