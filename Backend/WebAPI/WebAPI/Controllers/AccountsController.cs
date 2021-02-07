using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogic.BusinessLogicModels;
using BusinessLogic.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;
using WebApi.JWT;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        private readonly IJwtService _jwtService;

        public AccountsController(
            IAccountService accountService,
            IMapper mapper,
            IJwtService jwtService
        )
        {
            _accountService = accountService;
            _mapper = mapper;
            _jwtService = jwtService;
        }

        // POST api/accounts/login
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync([FromBody] AccountRequest accountRequest)
        {
            Account accountBl = _mapper.Map<Account>(accountRequest);

            Account authAccountBl = await _accountService.LoginAsync(accountBl);

            if (authAccountBl == null)
            {
                return BadRequest();
            }

            Account authAccount = _mapper.Map<Account>(authAccountBl);

            string token = _jwtService.CreateTokenAsync(authAccount);

            AccountResponse accountResponse = new AccountResponse(
                authAccount.Id,
                authAccount.FirstName,
                authAccount.SecondName,
                authAccount.Email,
                authAccount.Password,
                (int)authAccount.Role,
                token
            );

            return Ok(accountResponse);
        }

        // POST api/accounts/register
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] AccountRequest accountRequest)
        {
            Account accountBl = _mapper.Map<Account>(accountRequest);

            Account registerAccountBl = await _accountService.RegisterAsync(accountBl);

            if (registerAccountBl == null)
            {
                return BadRequest();
            }

            Account registerAccount = _mapper.Map<Account>(registerAccountBl);

            string token = _jwtService.CreateTokenAsync(registerAccount);

            AccountResponse accountResponse = new AccountResponse(
                registerAccount.Id,
                registerAccount.FirstName,
                registerAccount.SecondName,
                registerAccount.Email,
                registerAccount.Password,
                (int)registerAccount.Role,
                token
            );

            return Ok(accountResponse);
        }
    }
}
