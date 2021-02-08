using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace BusinessLogic.BusinessLogicModels
{
    public class AccountModels
    {
        public int? Id { get; init; }
        public string FirstName { get; init; }
        public string SecondName { get; init; }
        public string Email { get; init; }
        public string Password { get; init; }
        public AccountRole Role { get; init; }
    }
}
