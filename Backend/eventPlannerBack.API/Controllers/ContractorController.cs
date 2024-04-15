using eventPlannerBack.API.Exceptions;
using eventPlannerBack.BLL.Interfaces;
using eventPlannerBack.Models.VModels.ContractorDTO;
using Microsoft.AspNetCore.Mvc;

namespace eventPlannerBack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractorController : ControllerBase
    {
        private readonly IGenericService<ContractorCreationDTO, ContractorDTO> _genericService;
        private readonly IContractorService _contractorService;

        public ContractorController(
            IGenericService<ContractorCreationDTO, ContractorDTO> genericService,
            IContractorService contractorService)
        {
            _genericService = genericService;
            _contractorService = contractorService;
        }

        // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        [HttpGet("GetById")]
        public async Task<ActionResult<ContractorDTO>> GetById(string id)
        {
            try
            {
                var contractor = await _contractorService.GetById(id);

                return Ok(contractor);
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

        // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<ContractorDTO>>> GetAll()
        {
            try
            {
                var contractor = await _contractorService.GetAll();
                return Ok(contractor);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }


        // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        [HttpPost("Create")]
        public async Task<ActionResult<ContractorDTO>> SingIn(ContractorCreationDTO model)
        {
            try
            {
                var contractor = await _genericService.SignIn(model);

                return Ok(contractor);

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }


        // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("Update")]
        public async Task<ActionResult<ContractorDTO>> Update(string id, ContractorCreationDTO model)
        {
            try
            {
                var contractor = await _genericService.Update(id, model);

                return Ok(contractor);
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

        // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
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
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
