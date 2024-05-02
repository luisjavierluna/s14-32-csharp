using eventPlannerBack.Models.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventPlannerBack.DAL.SeedData
{
    public class SeedCity
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Province>().HasData(
                new Province() { Id = 1, Name = "Buenos Aires" },
                new Province() { Id = 2, Name = "Buenos Aires-GBA" },
                new Province() { Id = 3, Name = "Capital Federal" },
                new Province() { Id = 4, Name = "Catamarca" },
                new Province() { Id = 5, Name = "Chaco" },
                new Province() { Id = 6, Name = "Chubut" },
                new Province() { Id = 7, Name = "Córdoba" },
                new Province() { Id = 8, Name = "Corrientes" },
                new Province() { Id = 9, Name = "Entre Ríos" },
                new Province() { Id = 10, Name = "Formosa" },
                new Province() { Id = 11, Name = "Jujuy" },
                new Province() { Id = 12, Name = "La Pampa" },
                new Province() { Id = 13, Name = "La Rioja" },
                new Province() { Id = 14, Name = "Mendoza" },
                new Province() { Id = 15, Name = "Misiones" },
                new Province() { Id = 16, Name = "Neuquén" },
                new Province() { Id = 17, Name = "Río Negro" },
                new Province() { Id = 18, Name = "Salta" },
                new Province() { Id = 19, Name = "San Juan" },
                new Province() { Id = 20, Name = "San Luis" },
                new Province() { Id = 21, Name = "Santa Cruz" },
                new Province() { Id = 22, Name = "Santa Fe" },
                new Province() { Id = 23, Name = "Santiago del Estero" },
                new Province() { Id = 24, Name = "Tierra del Fuego" },
                new Province() { Id = 25, Name = "Tucumán" }
            );

        }
    }
}
