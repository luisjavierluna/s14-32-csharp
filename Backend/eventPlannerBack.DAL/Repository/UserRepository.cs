using eventPlannerBack.API.Exceptions;
using eventPlannerBack.DAL.Dbcontext;
using eventPlannerBack.DAL.Interfaces;
using eventPlannerBack.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace eventPlannerBack.DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly AplicationDBcontext _dbcontext;
        public UserRepository(UserManager<User> userManager, AplicationDBcontext dbcontext)
        {
            this._userManager = userManager;

            this._dbcontext = dbcontext;
        }

        public async Task<IdentityResult> SignIn(User model, string password)
        {
            var trasaction = await _dbcontext.Database.BeginTransactionAsync();
            try
            {
                var result = await _userManager.CreateAsync(model, password);
                if (!result.Succeeded) return result;

                var rolResult = await _userManager.AddToRoleAsync(model, "client");
                if (!rolResult.Succeeded)
                {
                    await trasaction.RollbackAsync();
                    return result;
                }
                await trasaction.CommitAsync();

                return result;
            }
            catch (Exception ex)
            {
                await trasaction.RollbackAsync();
                throw ex;
            }
        }

        public async Task<bool> UpdateByClientId(string dataId, string email)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(email);

                if (user == null) throw new NotFoundException();

                user.ClientId = dataId;

                _dbcontext.Update(user);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            try
            {
                var user = await _dbcontext.Users
                    .Where(user => user.Email == email)
                    .Include(user => user.Client).FirstOrDefaultAsync();

                if (user == null) throw new NotFoundException();

                return user;
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
                var roles = await _userManager.GetRolesAsync(user);

                string userRole = roles.FirstOrDefault() ?? "noRole";

                return userRole;
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
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null) throw new NotFoundException();

                string roleName = (await _userManager.GetRolesAsync(user)).FirstOrDefault() ?? "noRole";

                var result = await _userManager.RemoveFromRoleAsync(user, roleName);
                if (!result.Succeeded) throw new Exception("Failed to change role");

                roleName = roleName == "client" ? "contractor" : "client";
                result = await _userManager.AddToRoleAsync(user, roleName);
                if (!result.Succeeded) throw new Exception("Failed to change role");

                return roleName;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
