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

        public DbSet<Client> Clients { get; set; }

    }
}
