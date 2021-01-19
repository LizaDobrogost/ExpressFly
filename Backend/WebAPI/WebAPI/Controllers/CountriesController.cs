using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
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
            return await _countryService.GetAllAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            CountryModel foundCountryBl = await _countryService.GetAsync(id);

            Models.CountryModel foundCountryModel = _mapper.Map<Models.CountryModel>(foundCountryBl);

            if (foundCountryModel == null)
            {
                return NotFound();
            }

            return Ok(foundCountryModel);
        }

        [HttpPost]
        public async Task<ActionResult<CountryEntity>> AddAsync(Models.CountryModel countryModel)
        {
            CountryModel countryBl = _mapper.Map<CountryModel>(countryModel);

            await _countryService.AddAsync(countryBl);

            return Ok();
        }
    }
}