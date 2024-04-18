using eventPlannerBack.BLL.Behaviors;
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
        private readonly ValidationBehavior<UserCredentialsDTO> _validationBehavior;

        public AcountsController(
            IUserService userService,
            SignInManager<User> signInManager, 
            ITokenService tokenService, 
            IGenericService<ClientCreationDTO, ClientDTO> clientService,
            ValidationBehavior<UserCredentialsDTO> validationBehavior)
        {
            _userService = userService;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _clientService = clientService;
            _validationBehavior = validationBehavior;
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

                AuthDTO authResponse = await _userService.GetCredentialsAsync(model.Email);

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
                await _validationBehavior.ValidateFields(userCredentials);

                var result = await _signInManager.PasswordSignInAsync
                    (
                    userCredentials.Email, 
                    userCredentials.Password, 
                    isPersistent: false, 
                    lockoutOnFailure: false
                    );

                if (!result.Succeeded) return BadRequest("Wrong Credentials");

                AuthDTO authResponse = await _userService.GetCredentialsAsync(userCredentials.Email);

                return Ok(authResponse);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

    }
}
