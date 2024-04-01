using eventPlannerBack.BLL.Interfaces;
using eventPlannerBack.Models.Entities;
using eventPlannerBack.Models.VModels;
using eventPlannerBack.Models.VModels.Auth;
using eventPlannerBack.Models.VModels.DatosDTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

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
        private readonly IGenericService<DataCreationDTO, DataDTO> _dataService;

        public AcountsController(IUserService userService,SignInManager<User> signInManager, ITokenService tokenService, IGenericService<DataCreationDTO, DataDTO> dataService)
        {
            this._userService = userService;
            this._signInManager = signInManager;
            this._tokenService = tokenService;
            this._dataService = dataService;
        }

        [HttpPost("SignIn")]
        public async Task<ActionResult<AuthDTO>> Insert([FromBody]UserCreationDTO model) 
        {
            try
            {
                bool Result = await _userService.SignIn(model);
               if (!Result) 
                { 

                    return BadRequest("No se pudo agregar su User");
                }

           
                DataCreationDTO datas = new DataCreationDTO()
                {
                    Name = model.Name,
                    Surname = model.Surname
                };

                var registeredData = await _dataService.SignIn(datas);

                //model.DataId = registeredData.Id;
                var result = await _userService.UpdateDataId(registeredData.Id, model.Email);

                var token = _tokenService.GenerateToken(model.Email, 1);

                AuthDTO authResponse = new() { 
                           
                Token = token.Result
                };

                return Ok(authResponse);

            }
            catch (Exception)
            {

                return StatusCode(500, "Error interno del servidor");
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
