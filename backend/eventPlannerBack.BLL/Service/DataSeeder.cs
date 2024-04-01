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

            foreach (string rol in roles)
            {
                try
                {
                    var existeRol = await roleManager.RoleExistsAsync(roleName: rol);

                    if (!existeRol) await roleManager.CreateAsync(new IdentityRole(roleName: rol));

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

                var nuevoAdmin = new User { UserName = email, Email = email };

                var resultado = await userManager.CreateAsync(nuevoAdmin, "Admin123!");

                if (!resultado.Succeeded) throw new Exception("No se pudo crear el usuario administrador");

                var resultadoRol = await userManager.AddToRoleAsync(nuevoAdmin, "admin");

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
