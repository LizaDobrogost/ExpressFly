using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.BusinessLogicModels
{
    public class FlightFilterModel
    {
        public int? FromAirportId { get; init; }
        public int? ToAirportId { get; init; }
        public int? FromCityId { get; init; }
        public int? ToCityId { get; init; }
        public DateTime? DepartureDate { get; init; }
        public DateTime? ArrivalDate { get; init; }
        public int? TicketCount { get; init; }
        public bool SearchFlightsBack { get; init; }
        public DateTime? DepartureBackDate { get; init; }
        public DateTime? ArrivalBackDate { get; init; }
        public int CurrentPage { get; init; }
        public int PageLimit { get; init; }
    }
}
