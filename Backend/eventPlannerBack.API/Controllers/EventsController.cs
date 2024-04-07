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
            return Ok(new List<EventDTO>());
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
            return Created();
        }

        [Authorize]
        [HttpPut("postulation/{id}")]
        public async Task<ActionResult> PostulateEvent(string id)
        {
            return Ok();
        }

        [Authorize]
        [HttpPut("status/{id}")]
        public async Task<ActionResult> ChangeStatus(string id, [FromQuery(Name ="status")] int status)
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
