﻿using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BusinessLogic.BusinessLogicModels;
using BusinessLogic.Models;
using DataAccess.Entities;

namespace BusinessLogic
{
    public static class BusinessLogicMapping
    {
        public static void Initialize(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<CountryModel, CountryEntity>();
            configuration.CreateMap<CountryEntity, CountryModel>();

            configuration.CreateMap<Account, AccountEntity>();
            configuration.CreateMap<AccountEntity, Account>();
        }
    }
}
