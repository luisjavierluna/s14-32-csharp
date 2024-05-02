using eventPlannerBack.BLL.Interfaces;
using eventPlannerBack.Models.VModels.CityDTO;
using Microsoft.AspNetCore.Mvc;

namespace eventPlannerBack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICityService _cityService;
        public CitiesController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet("provinces")]
        public async Task<ActionResult<List<ProvinceDTO>>> GetProvinces([FromQuery(Name = "filter")] string? filter)
        {
            try
            {
                var provinces = await _cityService.GetAllProvincies(filter);
                return Ok(provinces);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<CityDTO>>> GetCities([FromQuery(Name = "filter")] string? filter, [FromQuery(Name = "provinceId")] int? provinceId)
        {
            try
            {
                var cities = await _cityService.GetCities(provinceId, filter);
                return Ok(cities);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}
