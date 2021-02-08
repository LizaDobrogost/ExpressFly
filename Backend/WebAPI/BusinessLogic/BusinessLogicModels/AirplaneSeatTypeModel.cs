using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.BusinessLogicModels
{
    public class AirplaneSeatTypeModel
    {
        public int? Id { get; init; }
        public string Name { get; init; }
        public int AirplaneId { get; init; }
        public string Color { get; init; }
    }
}
