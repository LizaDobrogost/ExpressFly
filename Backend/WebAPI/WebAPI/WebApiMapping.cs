using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogic.BusinessLogicModels;
using BusinessLogic.Models;
using WebAPI.Models;
using CountryModel = BusinessLogic.Models.CountryModel;

namespace WebApi
{
    public static class WebApiMapping
    {
        public static void Initialize(IMapperConfigurationExpression config)
        {
            config.CreateMap<City, CityModel>();
            config.CreateMap<CityModel, City>();

            config.CreateMap<Country,CountryModel>();
            config.CreateMap<CountryModel, Country>();

            config.CreateMap<Airport,AirportModel>();
            config.CreateMap<AirportModel, Airport>();

            config.CreateMap<Account, AccountModels>();
            config.CreateMap<AccountModels, Account>();
            config.CreateMap<AccountRequest, AccountModels>();

            config.CreateMap<Airplane, AirplaneModel>();
            config.CreateMap<AirplaneModel, Airplane>();
            config.CreateMap<AirplaneFilter, AirplaneFilter>();
            config.CreateMap<AirplaneSeat, AirplaneSeatModel>();
            config.CreateMap<AirplaneSeatModel, AirplaneSeat>();
            config.CreateMap<AirplaneSeatType, AirplaneSeatTypeModel>();
            config.CreateMap<AirplaneSeatTypeModel, AirplaneSeatType>();
            config.CreateMap<BusinessLogic.BusinessLogicModels.ItemsPage<Airplane>, WebAPI.Models.ItemsPage<Airplane>>();

            config.CreateMap<Flight, FlightModel>();
            config.CreateMap<FlightModel, Flight>();
            config.CreateMap<FlightSeatTypeCost, FlightSeatTypeCostModel>();
            config.CreateMap<FlightSeatTypeCostModel, FlightSeatTypeCost>();
            config.CreateMap<FlightFilter, FlightFilterModel>();
            config.CreateMap<FlightFilterModel, FlightFilter>();
            config.CreateMap<FlightBookInfoModel, FlightBookInfo>();
            config.CreateMap<SeatBook, SeatBookModel>();
            config.CreateMap<SeatBookModel, SeatBook>();
            config.CreateMap<BusinessLogic.BusinessLogicModels.ItemsPage<FlightModel>, WebAPI.Models.ItemsPage<Flight>>();
        }
    }
}