using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Services;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public async Task<IReadOnlyCollection<Country>> GetCountries()
        {
            return await _countryService.GetAllAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Country>> GetAsync(int id)
        {
            Country foundCountry = await _countryService.GetByIdAsync(id);

            if (foundCountry == null)
            {
                return NotFound();
            }

            return Ok(foundCountry);
        }

        [HttpPost]
        public async Task<ActionResult<Country>> AddAsync(Country country)
        {
            Country addCountry = await _countryService.AddAsync(country);

            return Ok(new { addCountry.Id });
        }
    }
}