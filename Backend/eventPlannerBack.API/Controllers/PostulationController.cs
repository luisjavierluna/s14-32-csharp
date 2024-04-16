using eventPlannerBack.API.Exceptions;
using eventPlannerBack.BLL.Interfaces;
using eventPlannerBack.Models.VModels.NotificationDTO;
using eventPlannerBack.Models.VModels.PostulationDTO;
using Microsoft.AspNetCore.Mvc;

namespace eventPlannerBack.API.Controllers
{
    public class PostulationController: ControllerBase
    {
        private readonly IGenericService<PostulationCreationDTO, PostulationDTO> _genericService;
        private readonly INotificationService _notificationService;

        public PostulationController(
            IGenericService<PostulationCreationDTO, PostulationDTO> genericService,
            INotificationService notificationService)
        {
            _genericService = genericService;
            _notificationService = notificationService;
        }
        [HttpGet("GetById")]
        public async Task<ActionResult<PostulationDTO>> GetById(string id)
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
        public async Task<ActionResult<IEnumerable<PostulationDTO>>> GetAll()
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

        [HttpPost("Insert")]
        public async Task<ActionResult<PostulationDTO>> Insert(PostulationCreationDTO model)
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
        public async Task<ActionResult<PostulationDTO>> Update(string id, PostulationCreationDTO model)
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
