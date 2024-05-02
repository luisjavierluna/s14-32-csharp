using eventPlannerBack.API.Exceptions;
using eventPlannerBack.BLL.Behaviors;
using eventPlannerBack.BLL.Interfaces;
using eventPlannerBack.Models.Entities;
using eventPlannerBack.Models.VModels;
using eventPlannerBack.Models.VModels.Auth;
using eventPlannerBack.Models.VModels.ContractorDTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace eventPlannerBack.API.Controllers
{
    [EnableCors("CorsRules")]
    [Route("api/[controller]")]
    [ApiController]
    public class AcountsController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly SignInManager<User> _signInManager;
        private readonly IGenericService<ContractorCreationDTO, ContractorDTO> _contractorService;
        private readonly ValidationBehavior<UserCredentialsDTO> _validationBehavior;

        public AcountsController(
            IUserService userService,
            SignInManager<User> signInManager, 
            IGenericService<ContractorCreationDTO, ContractorDTO> contractorService,
            ValidationBehavior<UserCredentialsDTO> validationBehavior)
        {
            _userService = userService;
            _signInManager = signInManager;
            _contractorService = contractorService;
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

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("ChangeRole")]
        public async Task<ActionResult<AuthDTO>> ChangeRole()
        {
            bool CUITConfirmed = await IsContractorCUITConfirmed();
            if (!CUITConfirmed) return BadRequest("CUIT needs to be added to enable role change");

            var claim = HttpContext.User.Claims.Where(c => c.Type == "id").FirstOrDefault();
            var userId = claim.Value;

            if (userId == null)
                return BadRequest("Id was not provided");

            var newRole = await _userService.ChangeRole(userId);

            var claim2 = HttpContext.User.Claims.Where(c => c.Type == "mail").FirstOrDefault();
            var mail = claim2.Value;

            AuthDTO authResponse = await _userService.GetCredentialsAsync(mail);

            return Ok(authResponse);
        }

        private async Task<bool> IsContractorCUITConfirmed()
        {
            try
            {
                var claim = HttpContext.User.Claims.Where(c => c.Type == "contractorid").FirstOrDefault();
                var contractorId = claim.Value;

                if (contractorId == null) throw new NotFoundException("Id was not provided");

                var contractor = await _contractorService.GetById(contractorId);

                bool isConfirmed = contractor.CUIT != null ? true : false;

                return isConfirmed;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
