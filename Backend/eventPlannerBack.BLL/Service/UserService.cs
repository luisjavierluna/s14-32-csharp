using eventPlannerBack.BLL.Behaviors;
using eventPlannerBack.BLL.Interfaces;
using eventPlannerBack.DAL.Interfaces;
using eventPlannerBack.Models.Entidades;
using eventPlannerBack.Models.Entities;
using eventPlannerBack.Models.VModels;
using eventPlannerBack.Models.VModels.Auth;

namespace eventPlannerBack.BLL.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly ValidationBehavior<UserCreationDTO> _validationBehavior;

        public UserService(IUserRepository userRepository, 
            ITokenService tokenService,
            ValidationBehavior<UserCreationDTO> validationBehavior)
        {
            _userRepository = userRepository;
            this._tokenService = tokenService;
            this._validationBehavior = validationBehavior;
        }

        public Task<bool> Update(User model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SignIn(UserCreationDTO model)
        {
            await _validationBehavior.ValidateFields(model);

            User User = new User()
            {
                UserName = model.Email,
                Email = model.Email,
                CreatedAt = DateTime.Now,

                FirstName = model.FirstName,
                LastName = model.LastName,
                ProfileImage = model.ProfileImage,
                IsActive = true,
                Client = new Client() { TaxCode = "0000000000000", CreatedAt = DateTime.Today, IsDeleted = false },
                Contractor = new Contractor() { CUIT = "00000000", CreatedAt = DateTime.Today, IsDeleted = false }
            };
            return await _userRepository.SignIn(User, model.Password);
        }

        public async Task<bool> UpdateClientId(string dataId, string email)
        {
            
            return await _userRepository.UpdateByClientId(dataId, email);
        }

        public async Task<AuthDTO> GetCredentialsAsync(string email)
        {
            try
            {
                var usuario = await _userRepository.GetByEmailAsync(email);

                var token = _tokenService.GenerateToken(email, 1);

                return new AuthDTO() { 
                           
                    Token = token.Result};



            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
