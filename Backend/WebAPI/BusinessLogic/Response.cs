using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Response
    {
        public ResultTypes ResultType { get; }
        
        public Response(ResultTypes resultType)
        {
            ResultType = resultType;
        }
    }
}