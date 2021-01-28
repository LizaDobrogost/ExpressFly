using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogic;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Services;
using DataAccess.Entities;
using WebApi.Models;
using CountryModel = BusinessLogic.Models.CountryModel;

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
        public async Task<IReadOnlyCollection<CountryModel>> GetCountries()
        {
            return await _countryService.GetAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            CountryModel foundCountry = await _countryService.GetAsync(id);

            CountryDto foundCountryDto = _mapper.Map<CountryDto>(foundCountry);

            if (foundCountryDto == null)
            {
                return NotFound();
            }

            return Ok(foundCountryDto);
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync(CountryDto countryDto)
        {
            CountryModel country = _mapper.Map<CountryModel>(countryDto);

            await _countryService.AddAsync(country);

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync(CountryDto country)
        {
            CountryModel countryModel = _mapper.Map<CountryModel>(country);

            await _countryService.UpdateAsync(countryModel);

            return Ok();
        }
    }
}