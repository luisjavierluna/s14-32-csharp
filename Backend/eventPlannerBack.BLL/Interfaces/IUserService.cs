using eventPlannerBack.Models.Entities;
using eventPlannerBack.Models.VModels;
using eventPlannerBack.Models.VModels.Auth;
using Microsoft.AspNetCore.Identity;

namespace eventPlannerBack.BLL.Interfaces
{
    public interface IUserService
    {
        Task<IdentityResult> SignIn(UserCreationDTO model);

        Task<bool> Update(User model);

        Task<bool> Delete(string id);

        Task<User> GetById(string id);

        Task<IQueryable<User>> GetAll();

        Task<bool> UpdateClientId(string clientId, string email);

        Task<AuthDTO> GetCredentialsAsync(string email);
        Task<string> GetUserRole(User user);
    }
}
