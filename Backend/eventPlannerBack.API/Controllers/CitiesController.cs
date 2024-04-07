using eventPlannerBack.BLL.Interfaces;
using eventPlannerBack.Models.VModels.CitiesDTO;
using eventPlannerBack.Models.VModels.CityDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eventPlannerBack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICityService _cityService;
        public CitiesController( ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet("provinces")]
        public async Task<ActionResult<List<ProvinceDTO>>> GetProvinces([FromQuery(Name ="filter")] string? filter)
        {
            return Ok(new List<ProvinceDTO>());
        }

        [HttpGet]
        public async Task<ActionResult<List<CityDTO>>> GetCities([FromQuery(Name = "filter")] string? filter, [FromQuery(Name = "provinceId")] int? provinceId)
        {
            return Ok(new List<CityDTO>());
        }
    }
}
