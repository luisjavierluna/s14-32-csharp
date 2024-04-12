using eventPlannerBack.API.Exceptions;
using eventPlannerBack.BLL.Interfaces;
using eventPlannerBack.Models.VModels.EventsDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eventPlannerBack.API.Controllers
{
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

        [Authorize]
        [HttpGet("myEvents")]
        public async Task<ActionResult<List<EventDTO>>> GetMyEvents()
        {
            try
            {
                //var claim = HttpContext.User.Claims.Where(c => c.Type == "id").FirstOrDefault();
                //var id = claim.Value;
                var id = "7f24ea09-4593-4800-931a-d946c54b3dff";
                var myEvents = await _eventService.GetMyEvents(id);
                return Ok(myEvents);
            }
            catch (Exception)
            {

                return StatusCode(500, "Error interno del servidor");
            }
        }

        [Authorize]
        [HttpGet("events")]
        public async Task<ActionResult<List<EventDTO>>> GetPostulable()
        {
            return Ok(new List<EventDTO>());
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> CreateEvent([FromBody] EventCreationDTO eventCreation)
        {
            try
            {
                //var claim = HttpContext.User.Claims.Where(c => c.Type == "id").FirstOrDefault();
                //var id = claim.Value;
                var id = "7f24ea09-4593-4800-931a-d946c54b3dff";
                await _eventService.Create(eventCreation, id);
                return Created();
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [Authorize]
        [HttpPut("postulation/{id}")]
        public async Task<ActionResult> PostulateEvent(string id)
        {
            return Ok();
        }

        [Authorize]
        [HttpPut("status/{id}")]
        public async Task<ActionResult> ChangeStatus(string id, [FromQuery(Name = "status")] int status)
        {
            return Ok();
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEvent([FromBody] EventCreationDTO eventCreation, string id)
        {
            return Ok();
        }
    }
}
