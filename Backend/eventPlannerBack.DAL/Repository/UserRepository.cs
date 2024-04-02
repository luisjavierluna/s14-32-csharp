using eventPlannerBack.API.Exceptions;
using eventPlannerBack.DAL.Interfaces;
using eventPlannerBack.DAL.Dbcontext;
using eventPlannerBack.Models.Entities;
using eventPlannerBack.Models.VModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventPlannerBack.DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> userManager;
        private readonly AplicationDBcontext _dbcontext;
        public UserRepository(UserManager<User> userManager, AplicationDBcontext dbcontext)
        {
            this.userManager = userManager;

            this._dbcontext = dbcontext;
        }

        public async Task<bool> SignIn(User model, string password)
        {
            var trasaction = await _dbcontext.Database.BeginTransactionAsync();
            try
            {
                var result = await userManager.CreateAsync(model, password);
                if (!result.Succeeded) return false;
                var rolResult =   await userManager.AddToRoleAsync(model, "user");
                if (!rolResult.Succeeded) 
                { 
                    
                await trasaction.RollbackAsync();
                 return false;
                }
                await trasaction.CommitAsync();
                
                return true;
            }
            catch (Exception ex)
            {
                await trasaction.RollbackAsync();
                return false;
            }
        }

        public async Task<bool> UpdateByDataId(int dataId, string email)
        {
            try
            {
                var user = await userManager.FindByEmailAsync(email);

                if (user == null) throw new NotFoundException();

                user.DataId= dataId;

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
                var user = await _dbcontext.Users.Where(user => user.Email == email).Include(user => user.Data).FirstOrDefaultAsync();

                if(user == null) throw new NotFoundException();


                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }



    }

     

        
    
}
