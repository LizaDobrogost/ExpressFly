using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Services;
using DataAccess.Entities;
using WebApi.Models;
using BlCountry = BusinessLogic.Models.Country;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryService _countryService;
        private readonly IMapper _mapper;

        public CountriesController(ICountryService countryService, IMapper mapper)
        {
            _countryService = countryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IReadOnlyCollection<BlCountry>> GetCountries()
        {
            return await _countryService.GetAllAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            BlCountry foundCountryBl = await _countryService.GetAsync(id);

            Country foundCountry = _mapper.Map<Country>(foundCountryBl);

            if (foundCountry == null)
            {
                return NotFound();
            }

            return Ok(foundCountry);
        }

        [HttpPost]
        public async Task<ActionResult<CountryEntity>> AddAsync(Country country)
        {
            BlCountry countryBl = _mapper.Map<BlCountry>(country);

            await _countryService.AddAsync(countryBl);

            return Ok();
        }
    }
}