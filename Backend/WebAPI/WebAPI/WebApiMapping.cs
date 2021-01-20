using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogic.Models;
using WebApi.Models;
using CountryModel = BusinessLogic.Models.CountryModel;

namespace WebApi
{
    public static class WebApiMapping
    {
        public static void Initialize(IMapperConfigurationExpression config)
        {
            config.CreateMap<Models.CountryDto, CountryModel>();
            config.CreateMap<CountryModel, Models.CountryDto>();
        }
    }
}