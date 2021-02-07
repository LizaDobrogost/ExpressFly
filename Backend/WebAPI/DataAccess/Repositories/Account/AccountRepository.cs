using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Data;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.Account
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AirlineContext _context;

        public AccountRepository(AirlineContext context)
        {
            _context = context;
        }

        public async Task<AccountEntity> GetByEmailAsync(string email)
        {
            return await _context
                .Accounts
                .FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<bool> CheckPasswordAsync(string password)
        {
            return await _context
                .Accounts
                .AnyAsync(s => s.Password.Equals(password));
        }

        public async Task<bool> CheckDuplicateAsync(AccountEntity account)
        {
            return await _context
                .Accounts
                .AnyAsync(s => s.Email.Equals(account.Email));
        }

        public async Task<AccountEntity> CreateAccountAsync(AccountEntity account)
        {
            await _context.AddAsync(account);
            await _context.SaveChangesAsync();
            return account;
        }
    }
}
