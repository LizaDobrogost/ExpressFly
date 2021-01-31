using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.BusinessLogicModels;

namespace BusinessLogic.Services
{
    public interface IAccountService
    {
        Task<Account> LoginAsync(Account account);
        Task<Account> RegisterAsync(Account account);
    }
}