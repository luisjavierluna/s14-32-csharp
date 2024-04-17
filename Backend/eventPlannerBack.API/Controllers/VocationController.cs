using eventPlannerBack.API.Exceptions;
using eventPlannerBack.BLL.Interfaces;
using eventPlannerBack.Models.VModels.VocationDTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;

namespace eventPlannerBack.API.Controllers
{
    [EnableCors("CorsRules")]
    [Route("api/[controller]")]
    [ApiController]
  
    public class VocationController : ControllerBase
    {
        private readonly IVocationService _vocationService;

        public VocationController(IVocationService vocationService)
        {
            _vocationService = vocationService;
        }


        [HttpGet("GetAll")]        
        public async Task<ActionResult<IEnumerable<VocationDTO>>> GetAll()
        {
            try
            {
                var vocations = await _vocationService.GetAll();
                return Ok(vocations);

            }
            catch(Exception e)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VocationDTO>> GetById(string id)
        {
            try
            {
                var vocation = await _vocationService.GetById(id);
                return Ok(vocation);

            }            
            catch
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        [HttpPost("Register")]
        public async Task<ActionResult<VocationDTO>> Register(VocationCreationDTO model)
        {
            try
            {
                var vocation = await _vocationService.SignIn(model);
                return Ok(vocation);

            }
            catch
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        [HttpPost("Delete")]       
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                var result = await _vocationService.Delete(id);

                return NoContent();

            }
            catch(NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
               

        [HttpPut("Update")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles ="admin")]
        public async Task<ActionResult> Update(string id, VocationCreationDTO model)
        {
            try
            {
                var vocation = await _vocationService.Update(id,model);
                return Ok(vocation);
            }
            catch(NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

     
    }
}
