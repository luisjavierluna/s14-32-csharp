using eventPlannerBack.BLL.Interfaces;
using eventPlannerBack.Models.Entities;
using eventPlannerBack.Models.VModels;
using eventPlannerBack.Models.VModels.Auth;
using eventPlannerBack.Models.VModels.ClientDTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace eventPlannerBack.API.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class AcountsController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IGenericService<ClientCreationDTO, ClientDTO> _clientService;

        public AcountsController(
            IUserService userService,
            SignInManager<User> signInManager, 
            ITokenService tokenService, 
            IGenericService<ClientCreationDTO, ClientDTO> clientService)
        {
            this._userService = userService;
            this._signInManager = signInManager;
            this._tokenService = tokenService;
            this._clientService = clientService;
        }

        [HttpPost("SignIn")]
        public async Task<ActionResult<AuthDTO>> Insert([FromBody]UserCreationDTO model) 
        {
            try
            {
                var Result = await _userService.SignIn(model);

                if (!Result.Succeeded) 
                { 
                    return BadRequest(Result.Errors);
                }

                var token = _tokenService.GenerateToken(model.Email, 1);

                AuthDTO authResponse = new() { Token = token.Result };

                return Ok(authResponse);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }


        [HttpPost("Login")]
        public async Task<ActionResult<AuthDTO>> Login([FromBody] UserCredentialsDTO userCredentials)
        {
            try
            {
                var result = await _signInManager.PasswordSignInAsync(userCredentials.Email, userCredentials.Password, isPersistent: false, lockoutOnFailure: false);

                if (!result.Succeeded) return BadRequest("Credenciales incorrectas");
            

                return Ok(await _userService.GetCredentialsAsync(userCredentials.Email));
            }
            catch (Exception)
            {

                return StatusCode(500, "Error interno del servidor");
            }


        }


    }
}
