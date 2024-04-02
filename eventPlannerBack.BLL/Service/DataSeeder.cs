using eventPlannerBack.BLL.Interfaces;
using eventPlannerBack.DAL.Interfaces;
using eventPlannerBack.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventPlannerBack.BLL.Service
{
    public class DataSeeder : IDataSeeder
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        

        public DataSeeder(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;            
        }

        

        public async Task CreateRoles()
        {
            string[] roles = { "admin", "user" };

            foreach (string role in roles)
            {
                try
                {
                    var roleExist = await roleManager.RoleExistsAsync(roleName: role);

                    if (!roleExist) await roleManager.CreateAsync(new IdentityRole(roleName: role));

                }
                catch (Exception)
                {

                    throw;
                }
            }

        }

        public async Task CreateUserAdmin()
        {
            try
            {
                string email = "admin@gmail.com";

                var admin = await userManager.FindByEmailAsync(email);

                if (admin != null) return;

                var newAdmin = new User { UserName = email, Email = email };

                var response = await userManager.CreateAsync(newAdmin, "Admin123!");

                if (!response.Succeeded) throw new Exception("No se pudo crear el usuario administrador");

                var roleResponse = await userManager.AddToRoleAsync(newAdmin, "admin");

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
