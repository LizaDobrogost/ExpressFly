using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class AddResult
    {
        public ResultTypes ResultType { get; }
        public int? ItemId { get; }

        public AddResult(ResultTypes resultType, int? itemId)
        {
            ResultType = resultType;
            ItemId = itemId;
        }
    }
}
