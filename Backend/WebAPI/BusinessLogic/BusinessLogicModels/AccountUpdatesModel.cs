using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.BusinessLogicModels
{
    public class AccountUpdates
    {
        public int AccountId { get; init; }
        public DateTimeOffset LastNameUpdateTime { get; init; }
        public DateTimeOffset LastAvatarUpdateTime { get; init; }
    }
}
