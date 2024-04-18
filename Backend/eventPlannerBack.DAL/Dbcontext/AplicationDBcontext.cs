using eventPlannerBack.DAL.SeedData;
using eventPlannerBack.Models.Entidades;
using eventPlannerBack.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;


namespace eventPlannerBack.DAL.Dbcontext
{
    public class AplicationDBcontext : IdentityDbContext<User>
    {
        public AplicationDBcontext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedCity.Seed(modelBuilder);
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Contractor> Contractors { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Event> Events { get; set; }
        // public DbSet<ImageEvent> ImageEvents { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Vocation> Vocations { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Postulation> Postulations { get; set; }

    }
}
