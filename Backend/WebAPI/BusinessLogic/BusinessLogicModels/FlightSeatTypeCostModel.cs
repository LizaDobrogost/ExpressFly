using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.BusinessLogicModels
{
    public class FlightSeatTypeCostModel
    {
        public int FlightId { get; init; }
        public int SeatTypeId { get; init; }
        public int Cost { get; init; }
    }
}
