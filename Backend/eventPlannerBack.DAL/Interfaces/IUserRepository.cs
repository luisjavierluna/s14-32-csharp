using eventPlannerBack.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace eventPlannerBack.DAL.Interfaces
{
    public interface IUserRepository
    {
        Task<IdentityResult> SignIn(User modelo, string password);

        Task<bool> UpdateByClientId(string clientId, string email);

        Task<User> GetByEmailAsync(string email);


    }
}
