using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace BusinessLogic.BusinessLogicModels
{
    public class FlightBookInfoModel
    {
        public int? Id { get; set; }
        public int FlightId { get; set; }
        public int SuitcaseOverloadCost { get; set; }
        public int HandLuggageOverloadCost { get; set; }
        public BookType BookType { get; set; }
        public DateTimeOffset BookTime { get; set; }
        public int AccountId { get; set; }
        public SeatBookModel[] SeatBooks { get; set; }
    }
}
