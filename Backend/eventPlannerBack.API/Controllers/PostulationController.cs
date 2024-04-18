using eventPlannerBack.API.Exceptions;
using eventPlannerBack.BLL.Interfaces;
using eventPlannerBack.Models.VModels.NotificationDTO;
using eventPlannerBack.Models.VModels.PostulationDTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace eventPlannerBack.API.Controllers
{
    [EnableCors("CorsRules")]
    [Route("api/[controller]")]
    [ApiController]
    public class PostulationController: ControllerBase
    {
        private readonly IGenericService<PostulationCreationDTO, PostulationDTO> _genericService;
        private readonly IPostulationService _PostulationService;

        public PostulationController(
            IGenericService<PostulationCreationDTO, PostulationDTO> genericService,
            IPostulationService notificationService)
        {
            _genericService = genericService;
            _PostulationService = notificationService;
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

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("Insert")]
        public async Task<ActionResult<PostulationDTO>> Insert(PostulationCreationDTO model)
        {
            try
            {
                var claim = HttpContext.User.Claims.Where(c => c.Type == "contractorid").FirstOrDefault();
                var id = claim.Value;
                model.ContractorId = id;
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

        [HttpPut("accept/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Accept(string id)
        {
            try
            {
                var claim = HttpContext.User.Claims.Where(c => c.Type == "clientid").FirstOrDefault();
                var clientid = claim.Value;
                await _PostulationService.Accept(id, clientid);
                return Ok();
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

        [HttpPut("refuse/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Refuse(string id)
        {
            try
            {
                var claim = HttpContext.User.Claims.Where(c => c.Type == "clientid").FirstOrDefault();
                var clientid = claim.Value;
                await _PostulationService.Refuse(id,clientid);
                return Ok();
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
