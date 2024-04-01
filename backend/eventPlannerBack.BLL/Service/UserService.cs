using eventPlannerBack.BLL.Interfaces;
using eventPlannerBack.DAL.Interfaces;
using eventPlannerBack.Models.Entities;
using eventPlannerBack.Models.VModels;
using eventPlannerBack.Models.VModels.Auth;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace eventPlannerBack.BLL.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public UserService( IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            this._tokenService = tokenService;
        }

        public Task<bool> Update(User model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SignIn(UserCreationDTO model)
        {
            User User = new User()
            {
                UserName = model.Email,
                Email = model.Email,
                CreationData = DateTime.Now,
            };
            return await _userRepository.SignIn(User, model.Password);
        }

        public async Task<bool> UpdateDataId(int dataId, string email)
        {
            
            return await _userRepository.UpdateByDataId(dataId, email);
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
