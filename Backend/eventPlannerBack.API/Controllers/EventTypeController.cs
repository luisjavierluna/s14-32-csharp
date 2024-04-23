using eventPlannerBack.BLL.Interfaces;
using eventPlannerBack.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace eventPlannerBack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventTypeController : ControllerBase
    {
        private readonly IEventTypeService _eventTypeService;
        public EventTypeController(IEventTypeService eventTypeService)
        {
            _eventTypeService = eventTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<EventType>>> GetAll() 
        {
            try
            {
                var eventTypes = await _eventTypeService.GetAll();
                return Ok(eventTypes);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}
