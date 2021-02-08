using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.BusinessLogicModels
{
    public class AirplaneSeatModel
    {
        public int Id { get; init; }
        public int AirplaneId { get; init; }
        public int Floor { get; init; }
        public int Section { get; init; }
        public int Zone { get; init; }
        public int Row { get; init; }
        public int Number { get; init; }
        public int TypeId { get; init; }
    }
}
