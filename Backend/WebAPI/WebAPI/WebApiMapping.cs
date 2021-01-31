using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogic.BusinessLogicModels;
using BusinessLogic.Models;
using WebApi.DTOs;
using WebApi.Models;

namespace WebApi
{
    public static class WebApiMapping
    {
        public static void Initialize(IMapperConfigurationExpression config)
        {
            config.CreateMap<CountryDto, CountryModel>();
            config.CreateMap<CountryModel, CountryDto>();

            config.CreateMap<Account, AccountRequest>();
            config.CreateMap<AccountRequest, Account>();
        }
    }
}