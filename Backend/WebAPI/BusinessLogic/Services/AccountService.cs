using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogic.BusinessLogicModels;
using DataAccess.Entities;
using DataAccess.Repositories;
using DataAccess.Repositories.Account;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BusinessLogic.Services
{
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly IAccountRepository _accountRepository;

        public AccountService(
            IMapper mapper,
            IAccountRepository repository
        )
        {
            _mapper = mapper;
            _accountRepository = repository;
        }

        public async Task<Account> LoginAsync(Account account)
        {
            AccountEntity dalAccount = await _accountRepository.GetByEmailAsync(account.Email);

            if (dalAccount == null)
            {
                throw new InvalidDataException("This email doesn't exist");
            }

            return _mapper.Map<Account>(dalAccount);
        }

        public async Task<Account> RegisterAsync(Account account)
        {
            AccountEntity dalAccount = _mapper.Map<AccountEntity>(account);

            bool duplicate = await _accountRepository.CheckDuplicateAsync(dalAccount);

            if (duplicate)
            {
                throw new InvalidDataException("Account with this email already exists");
            }

            AccountEntity newAccount = await _accountRepository.CreateAccountAsync(dalAccount);

            return _mapper.Map<Account>(newAccount);
        }

    }
}