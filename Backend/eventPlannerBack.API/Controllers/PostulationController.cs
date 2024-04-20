using eventPlannerBack.API.Exceptions;
using eventPlannerBack.BLL.Interfaces;
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
        private readonly IPostulationService _postulationService;

        public PostulationController(
            IGenericService<PostulationCreationDTO, PostulationDTO> genericService,
            IPostulationService postulationService)
        {
            _genericService = genericService;
            _postulationService = postulationService;
        }
        [HttpGet("GetById")]
        public async Task<ActionResult<PostulationDTO>> GetById(string id)
        {
            try
            {
                var postulation = await _genericService.GetById(id);

                return Ok(postulation);
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
                var postulations = await _genericService.GetAll();
                return Ok(postulations);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "contractor")]
        [HttpGet("GetMyPostulations")]
        public async Task<ActionResult<IEnumerable<PostulationDTO>>> GetMyPostulations()
        {
            try
            {
                var claim = HttpContext.User.Claims.Where(c => c.Type == "contractorid").FirstOrDefault();
                var contractorId = claim.Value;

                if (contractorId == null)
                    return BadRequest("Id was not provided");

                var postulations = await _postulationService.GetMyPostulations(contractorId);
                return Ok(postulations);

            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "contractor")]
        [HttpPost("Insert")]
        public async Task<ActionResult<PostulationDTO>> Insert(PostulationCreationDTO model)
        {
            try
            {
                var claim = HttpContext.User.Claims.Where(c => c.Type == "contractorid").FirstOrDefault();
                var id = claim.Value;
                model.ContractorId = id;
                var postulation = await _genericService.SignIn(model);

                return Ok(postulation);
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
                var postulation = await _genericService.Update(id, model);

                return Ok(postulation);
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
                await _postulationService.Accept(id, clientid);
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
                await _postulationService.Refuse(id,clientid);
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
