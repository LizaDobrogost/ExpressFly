using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.BusinessLogicModels
{
    public class FlightModel
    {
        public int Id { get; set; }
        public int FromAirportId { get; set; }
        public int ToAirportId { get; set; }
        public DateTimeOffset DepartureTime { get; set; }
        public DateTimeOffset ArrivalTime { get; set; }
        public int AirplaneId { get; set; }
    }
}
