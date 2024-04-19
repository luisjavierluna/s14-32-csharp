using eventPlannerBack.BLL.Interfaces;
using eventPlannerBack.Models.Entidades;
using eventPlannerBack.Models.Entities;
using Microsoft.AspNetCore.Identity;
using System.Runtime.CompilerServices;

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
        public async Task CreateClientUsers()
        {
            foreach (var defaultUser in Clients)
            {
                if (userManager.Users.All(u => u.Id != defaultUser.Id))
                {
                    var user = await userManager.FindByEmailAsync(defaultUser.Email);
                    if (user == null)
                    {
                        await userManager.CreateAsync(defaultUser, "123Pa$word");
                        await userManager.AddToRoleAsync(defaultUser, "client");
                    }
                }
            }
        }

        public async Task CreateContractorUsers()
        {
            foreach (var defaultUser in Contractors)
            {
                if (userManager.Users.All(u => u.Id != defaultUser.Id))
                {
                    var user = await userManager.FindByEmailAsync(defaultUser.Email);
                    if (user == null)
                    {
                        await userManager.CreateAsync(defaultUser, "123Pa$word");
                        await userManager.AddToRoleAsync(defaultUser, "contractor");
                    }
                }
            }
        }

        public static ICollection<User> Clients = new List<User>
        {
            new ()
            {
                FirstName = "Alice",
                LastName = "Johnson",
                ProfileImage = "Alice Image",
                Email = "alice.johnson@example.com",
                UserName = "alice.johnson@example.com",
                PhoneNumber = "555-1234",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                CreatedAt = DateTime.Today,
                IsActive = true,
                Client = new Client() { CreatedAt = DateTime.Today, IsDeleted = false },
                Contractor = new Contractor() { CreatedAt = DateTime.Today, IsDeleted = false }
            },
            new ()
            {
                FirstName = "Bob",
                LastName = "Smith",
                ProfileImage = "Bob Image",
                Email = "bob.smith@example.com",
                UserName = "bob.smith@example.com",
                PhoneNumber = "555-5678",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                CreatedAt = DateTime.Today,
                IsActive = true,
                Client = new Client() { CreatedAt = DateTime.Today, IsDeleted = false },
                Contractor = new Contractor() { CreatedAt = DateTime.Today, IsDeleted = false }
            },
            new ()
            {
                FirstName = "Charlie",
                LastName = "Brown",
                ProfileImage = "Charlie Image",
                Email = "charlie.brown@example.com",
                UserName = "charlie.brown@example.com",
                PhoneNumber = "555-9876",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                CreatedAt = DateTime.Today,
                IsActive = true,
                Client = new Client() { CreatedAt = DateTime.Today, IsDeleted = false },
                Contractor = new Contractor() { CreatedAt = DateTime.Today, IsDeleted = false }
            },
            new ()
            {
                FirstName = "David",
                LastName = "Miller",
                ProfileImage = "David Image",
                Email = "david.miller@example.com",
                UserName = "david.miller@example.com",
                PhoneNumber = "555-4321",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                CreatedAt = DateTime.Today,
                IsActive = true,
                Client = new Client() { CreatedAt = DateTime.Today, IsDeleted = false },
                Contractor = new Contractor() { CreatedAt = DateTime.Today, IsDeleted = false }
            },
            new ()
            {
                FirstName = "Ella",
                LastName = "Garcia",
                ProfileImage = "Ella Image",
                Email = "ella.garcia@example.com",
                UserName = "ella.garcia@example.com",
                PhoneNumber = "555-2468",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                CreatedAt = DateTime.Today,
                IsActive = true,
                Client = new Client() { CreatedAt = DateTime.Today, IsDeleted = false },
                Contractor = new Contractor() { CreatedAt = DateTime.Today, IsDeleted = false }
            },
        };

        public static ICollection<User> Contractors = new List<User>
        {
            new ()
            {
                FirstName = "Fiona",
                LastName = "Lee",
                ProfileImage = "Fiona Image",
                Email = "fiona.lee@example.com",
                UserName = "fiona.lee@example.com",
                PhoneNumber = "555-1357",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                CreatedAt = DateTime.Today,
                IsActive = true,
                Client = new Client() { CreatedAt = DateTime.Today, IsDeleted = false },
                Contractor = new Contractor() { CUIT = "11111", CreatedAt = DateTime.Today, IsDeleted = false }
            },
            new ()
            {
                FirstName = "George",
                LastName = "Wang",
                ProfileImage = "George Image",
                Email = "george.wang@example.com",
                UserName = "george.wang@example.com",
                PhoneNumber = "555-8642",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                CreatedAt = DateTime.Today,
                IsActive = true,
                Client = new Client() { CreatedAt = DateTime.Today, IsDeleted = false },
                Contractor = new Contractor() { CUIT = "22222", CreatedAt = DateTime.Today, IsDeleted = false }
            },
            new ()
            {
                FirstName = "Hannah",
                LastName = "Choi",
                ProfileImage = "Hannah Image",
                Email = "hannah.choi@example.com",
                UserName = "hannah.choi@example.com",
                PhoneNumber = "555-9753",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                CreatedAt = DateTime.Today,
                IsActive = true,
                Client = new Client() { CreatedAt = DateTime.Today, IsDeleted = false },
                Contractor = new Contractor() { CUIT = "33333", CreatedAt = DateTime.Today, IsDeleted = false }
            },
            new ()
            {
                FirstName = "Isaac",
                LastName = "Martinez",
                ProfileImage = "Isaac Image",
                Email = "isaac.martinez@example.com",
                UserName = "isaac.martinez@example.com",
                PhoneNumber = "555-2468",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                CreatedAt = DateTime.Today,
                IsActive = true,
                Client = new Client() { CreatedAt = DateTime.Today, IsDeleted = false },
                Contractor = new Contractor() { CUIT = "44444", CreatedAt = DateTime.Today, IsDeleted = false }
            },
            new ()
            {
                FirstName = "Julia",
                LastName = "Nguyen",
                ProfileImage = "Julia Image",
                Email = "julia.nguyen@example.com",
                UserName = "julia.nguyen@example.com",
                PhoneNumber = "555-7890",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                CreatedAt = DateTime.Today,
                IsActive = true,
                Client = new Client() { CreatedAt = DateTime.Today, IsDeleted = false },
                Contractor = new Contractor() { CUIT = "55555", CreatedAt = DateTime.Today, IsDeleted = false }
            },
        };
    }
}
