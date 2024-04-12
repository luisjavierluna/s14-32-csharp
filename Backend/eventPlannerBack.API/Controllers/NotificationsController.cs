using eventPlannerBack.BLL.Interfaces;
using eventPlannerBack.Models.VModels.NotificationDTO;
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

        [HttpPost("InsertNotification")]
        public async Task<ActionResult<NotificationDTO>> SingIn(NotificationCreationDTO model)
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
    }
}
