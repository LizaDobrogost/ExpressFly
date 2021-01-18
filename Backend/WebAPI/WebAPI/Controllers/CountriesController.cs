using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Services;
using DataAccess.Entities;
using WebApi.Models;

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
        public async Task<IReadOnlyCollection<CountryBusinessModel>> GetCountries()
        {
            return await _countryService.GetAllAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            CountryBusinessModel foundCountryBl = await _countryService.GetAsync(id);

            CountryModel foundCountryModel = _mapper.Map<CountryModel>(foundCountryBl);

            if (foundCountryModel == null)
            {
                return NotFound();
            }

            return Ok(foundCountryModel);
        }

        [HttpPost]
        public async Task<ActionResult<CountryEntity>> AddAsync(CountryModel countryModel)
        {
            CountryBusinessModel countryBl = _mapper.Map<CountryBusinessModel>(countryModel);

            await _countryService.AddAsync(countryBl);

            return Ok();
        }
    }
}