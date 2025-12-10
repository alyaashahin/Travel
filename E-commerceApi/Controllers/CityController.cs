using Travel.DTOs.CityDto;
using Travel.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Travel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCity([FromForm] CreateCityDto createCityDto)
        {
            var response = await _cityService.CreateCityAsync(createCityDto);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCities()
        {
            var response = await _cityService.GetAllCitiesAsync();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCityById(int id)
        {
            var response = await _cityService.GetCityByIdAsync(id);

            if (!response.Success)
                return NotFound(response);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCity(int id, [FromForm] CreateCityDto createCityDto)
        {
            var response = await _cityService.UpdateCityAsync(id, createCityDto);

            if (!response.Success)
                return NotFound(response);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            var response = await _cityService.DeleteCityAsync(id);

            if (!response.Success)
                return NotFound(response);

            return Ok(response);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchCitiesByName([FromQuery] string name)
        {
            var response = await _cityService.SearchCitiesByNameAsync(name);
            return Ok(response);
        }
    }
}
