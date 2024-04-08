using eventPlannerBack.Models.Entities;
using eventPlannerBack.Models.VModels;
using eventPlannerBack.Models.VModels.Auth;

namespace eventPlannerBack.BLL.Interfaces
{
    public interface IUserService
    {
        Task<bool> SignIn(UserCreationDTO model);

        Task<bool> Update(User model);

        Task<bool> Delete(int id);

        Task<User> GetById(int id);

        Task<IQueryable<User>> GetAll();

        Task<bool> UpdateClientId(int clientId, string email);

        Task<AuthDTO> GetCredentialsAsync(string email);

    }
}
