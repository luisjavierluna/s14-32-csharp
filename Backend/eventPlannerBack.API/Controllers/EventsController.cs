using eventPlannerBack.API.Exceptions;
using eventPlannerBack.BLL.Interfaces;
using eventPlannerBack.Models.VModels.EventsDTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace eventPlannerBack.API.Controllers
{
    [EnableCors("CorsRules")]
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;
        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventDTO>> GetEvent(string id)
        {
            return Ok(new EventDTO());
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("myEvents")]
        public async Task<ActionResult<List<EventDTO>>> GetMyEvents()
        {
            try
            {
                var claim = HttpContext.User.Claims.Where(c => c.Type == "clientid").FirstOrDefault();
                var id = claim.Value;
                var myEvents = await _eventService.GetMyEvents(id);
                return Ok(myEvents);
            }
            catch (Exception)
            {

                return StatusCode(500, "Error interno del servidor");
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("myEvents/inactive")]
        public async Task<ActionResult<List<EventDTO>>> GetMyInactiveEvents()
        {
            try
            {
                var claim = HttpContext.User.Claims.Where(c => c.Type == "clientid").FirstOrDefault();
                var id = claim.Value;
                var myEvents = await _eventService.GetMyInactiveEvents(id);
                return Ok(myEvents);
            }
            catch (Exception)
            {

                return StatusCode(500, "Error interno del servidor");
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("events")]
        public async Task<ActionResult<List<EventDTO>>> GetPostulable()
        {
            return Ok(new List<EventDTO>());
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public async Task<ActionResult> CreateEvent([FromBody] EventCreationDTO eventCreation)
        {
            try
            {
                var claim = HttpContext.User.Claims.Where(c => c.Type == "clientid").FirstOrDefault();
                var id = claim.Value;
                await _eventService.Create(eventCreation, id);
                return Created();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("postulation/{id}")]
        public async Task<ActionResult> PostulateEvent(string id)
        {
            return Ok();
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("status/{id}")]
        public async Task<ActionResult> ChangeStatus(string id, [FromQuery(Name = "status")] int status)
        {
            return Ok();
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEvent([FromBody] EventCreationDTO eventCreation, string id)
        {
            try
            {
                await _eventService.Update(id, eventCreation);
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("activeInactive/{id}")]
        public async Task<ActionResult> ActiveInactive(string id)
        {
            try
            {
                await _eventService.ActiveInactive(id);
                return Ok();
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
