using AutoMapper;
using eventPlannerBack.BLL.Behaviors;
using eventPlannerBack.BLL.Interfaces;
using eventPlannerBack.DAL.Interfaces;
using eventPlannerBack.DAL.Migrations;
using eventPlannerBack.Models.Entidades;
using eventPlannerBack.Models.Entities;
using eventPlannerBack.Models.VModels;
using eventPlannerBack.Models.VModels.Auth;
using eventPlannerBack.Models.VModels.VocationDTO;
using Microsoft.AspNetCore.Identity;

namespace eventPlannerBack.BLL.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly ValidationBehavior<UserCreationDTO> _validationBehavior;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, 
            ITokenService tokenService,
            ValidationBehavior<UserCreationDTO> validationBehavior,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _validationBehavior = validationBehavior;
            _mapper = mapper;
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

        public async Task<IdentityResult> SignIn(UserCreationDTO model)
        {
            try
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
                    PhoneNumber = model.PhoneNumber,
                    IsActive = true,
                    Client = new Client() { CreatedAt = DateTime.Today, IsDeleted = false },
                    Contractor = new Contractor() { CreatedAt = DateTime.Today, IsDeleted = false }
                };

                return await _userRepository.SignIn(User, model.Password);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> UpdateClientId(string dataId, string email)
        {
            
            return await _userRepository.UpdateByClientId(dataId, email);
        }

        public async Task<AuthDTO> GetCredentialsAsync(string email)
        {
            try
            {
                User user = await _userRepository.GetByEmailAsync(email);
                string role = await GetUserRole(user);

                UserDTO dto = _mapper.Map<UserDTO>(user);
                dto.Role = role;
                if(user.Contractor.ContractorsVocations != null)
                {
                    dto.contractor.Vocations =
                    _mapper.Map<List<VocationDTO>>(user.Contractor
                    .ContractorsVocations
                    .Select(x => x.Vocation).ToList());
                }

                var token = _tokenService.GenerateToken(email, 1);

                return new AuthDTO() { 
                           
                    Token = token.Result,
                    User = dto
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> GetUserRole(User user)
        {
            try
            {
                return await _userRepository.GetUserRole(user);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> ChangeRole(string userId)
        {
            try
            {
                return await _userRepository.ChangeRole(userId);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
