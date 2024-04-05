using eventPlannerBack.API.Exceptions;
using eventPlannerBack.BLL.Interfaces;
using eventPlannerBack.Models.Entities;
using eventPlannerBack.Models.VModels.DatosDTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace eventPlannerBack.API.Controllers
{
    [EnableCors("ReglasCors")]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly IGenericService<DataCreationDTO, DataDTO> _dataService;
        private readonly IDataService _dataService1;
        private readonly UserManager<User> _userManager;

        public DataController(IGenericService<DataCreationDTO, DataDTO> dataService, IDataService dataService1,UserManager<User> userManager)
        {
            _dataService = dataService;
            _dataService1 = dataService1;
            _userManager = userManager;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        [HttpGet("GetById")]
        public async Task<ActionResult<DataDTO>> GetById(int id) 
        {
            try
            {
                var data = await _dataService.GetById(id);

                return Ok(data);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {

                return StatusCode(500, "Error interno del servidor");
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<DataDTO>>> GetAll()
        {
            try 
            { 
                var data = await  _dataService.GetAll();
                return Ok(data);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor");
            }
        }
     

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        [HttpPost("InsertData")]
        public async Task<ActionResult<DataDTO>>SingIn(DataCreationDTO model) 
        {
            try
            {
                var data = await _dataService.SignIn(model);

                return Ok(data);

            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("UpdateData")]
        public async Task<ActionResult<DataDTO>>Update(int id, DataCreationDTO model) 
        {   
            try 
            {
                var data = await _dataService.Update(id, model);

                return Ok(data);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles ="admin")]
        [HttpDelete("Delete Data")]
        public async Task<IActionResult> Delete(int id)
        {
            try 
            { 
               var resultado = await _dataService.Delete(id);

                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor");
            }
        }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpGet("MyData")]
    public async Task<ActionResult<DataDTO>> GetById()
    {
        try
        {
            var claim = HttpContext.User.Claims.Where(c => c.Type == "id").FirstOrDefault();
            var user = await _userManager.FindByIdAsync(claim.Value);                
            var data = await _dataService.GetById((int)user.DataId);

            return Ok(data);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception)
        {

            return StatusCode(500, "Error interno del servidor");
        }
    }
    }

}
