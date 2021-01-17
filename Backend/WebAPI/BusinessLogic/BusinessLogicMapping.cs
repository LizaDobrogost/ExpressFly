using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BusinessLogic.Models;
using DataAccess.Entities;

namespace BusinessLogic
{
    public static class BusinessLogicMapping
    {
        public static void Mapp(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Country, CountryEntity>();
            configuration.CreateMap<CountryEntity, Country>();
        }
    }
}
