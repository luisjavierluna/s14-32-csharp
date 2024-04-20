using eventPlannerBack.API.Exceptions;
using eventPlannerBack.BLL.Interfaces;
using eventPlannerBack.Models.VModels.NotificationDTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eventPlannerBack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly IGenericService<NotificationCreationDTO, NotificationDTO> _genericService;
        private readonly INotificationService _notificationService;

        public NotificationsController(
            IGenericService<NotificationCreationDTO, NotificationDTO> genericService, 
            INotificationService notificationService)
        {
            _genericService = genericService;
            _notificationService = notificationService;
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<NotificationDTO>> GetById(string id)
        {
            try
            {
                var notification = await _genericService.GetById(id);

                return Ok(notification);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {

                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<NotificationDTO>>> GetAll()
        {
            try
            {
                var notifications = await _genericService.GetAll();
                return Ok(notifications);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("GetMyNotifications")]
        public async Task<ActionResult<IEnumerable<NotificationDTO>>> GetMyNotifications()
        {
            try
            {
                var claim = HttpContext.User.Claims.Where(c => c.Type == "id").FirstOrDefault();
                var userId = claim.Value;

                if (userId == null)
                    return BadRequest("Id was not provided");

                var notifications = await _notificationService.GetMyNotifications(userId);
                return Ok(notifications);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost("Insert")]
        public async Task<ActionResult<NotificationDTO>> Insert(NotificationCreationDTO model)
        {
            try
            {
                var notification = await _genericService.SignIn(model);

                return Ok(notification);
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<ActionResult<NotificationDTO>> Update(string id, NotificationCreationDTO model)
        {
            try
            {
                var notification = await _genericService.Update(id, model);

                return Ok(notification);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var resultado = await _genericService.Delete(id);

                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
