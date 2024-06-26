﻿using eventPlannerBack.API.Exceptions;
using eventPlannerBack.BLL.Interfaces;
using eventPlannerBack.Models.Entities;
using eventPlannerBack.Models.VModels.ClientDTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace eventPlannerBack.API.Controllers
{
    // [EnableCors("ReglasCors")]
    // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IGenericService<ClientCreationDTO, ClientDTO> _clientService;
        private readonly IClientService _clientService1;
        private readonly UserManager<User> _userManager;

        public ClientsController(
            IGenericService<ClientCreationDTO, ClientDTO> clientService,
            IClientService clientService1,
            UserManager<User> userManager)
        {
            _clientService = clientService;
            _clientService1 = clientService1;
            _userManager = userManager;
        }

        // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        [HttpGet("GetById")]
        public async Task<ActionResult<ClientDTO>> GetById(string id)
        {
            try
            {
                var client = await _clientService.GetById(id);

                return Ok(client);
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
        public async Task<ActionResult<IEnumerable<ClientDTO>>> GetAll()
        {
            try
            {
                var client = await _clientService.GetAll();
                return Ok(client);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }


        // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        [HttpPost("Create")]
        public async Task<ActionResult<ClientDTO>> SingIn(ClientCreationDTO model)
        {
            try
            {
                var client = await _clientService.SignIn(model);

                return Ok(client);

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }


        // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("Update")]
        public async Task<ActionResult<ClientDTO>> Update(string id, ClientCreationDTO model)
        {
            try
            {
                var client = await _clientService.Update(id, model);

                return Ok(client);
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
                var resultado = await _clientService.Delete(id);

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
