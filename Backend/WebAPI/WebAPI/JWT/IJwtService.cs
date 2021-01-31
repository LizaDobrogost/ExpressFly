using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.BusinessLogicModels;

namespace WebApi.JWT
{
    public interface IJwtService
    {
        string CreateTokenAsync(Account account);
    }
}
