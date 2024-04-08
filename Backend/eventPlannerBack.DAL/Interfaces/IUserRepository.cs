using eventPlannerBack.Models.Entities;

namespace eventPlannerBack.DAL.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> SignIn(User modelo, string password);

        Task<bool> UpdateByClientId(int clientId, string email);

        Task<User> GetByEmailAsync(string email);


    }
}
