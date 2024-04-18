﻿using eventPlannerBack.BLL.Interfaces;
using eventPlannerBack.Models.Entidades;
using eventPlannerBack.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace eventPlannerBack.BLL.Service
{
    public class ClientSeeder : IClientSeeder
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public ClientSeeder(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;            
        }

        public async Task CreateRoles()
        {
            string[] roles = { "admin", "client", "contractor" };

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

                var newAdmin = new User
                {
                    UserName = email,
                    Email = email,
                    FirstName = "Admin",
                    LastName = "Admin",
                    PhoneNumber = "Phone Example",
                    ProfileImage = "Image Example",
                    CreatedAt = DateTime.Today,
                    IsActive = true,
                    Client = new Client() { CreatedAt = DateTime.Today, IsDeleted = false },
                    Contractor = new Contractor() { CreatedAt = DateTime.Today, IsDeleted = false }
                };

                var response = await userManager.CreateAsync(newAdmin, "Admin123!");

                if (!response.Succeeded) throw new Exception("Failed to create administrator user");

                var roleResponse = await userManager.AddToRoleAsync(newAdmin, "admin");

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
