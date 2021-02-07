using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess.Repositories.Account
{
    public interface IAccountRepository
    {
        Task<AccountEntity> GetByEmailAsync(string email);
        Task<bool> CheckDuplicateAsync(AccountEntity account);
        Task<AccountEntity> CreateAccountAsync(AccountEntity account);
        Task<bool> CheckPasswordAsync(string password);
    }
}
