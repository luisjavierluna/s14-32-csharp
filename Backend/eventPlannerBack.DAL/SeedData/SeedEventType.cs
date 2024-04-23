using eventPlannerBack.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace eventPlannerBack.DAL.SeedData
{
    public class SeedEventType
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventType>().HasData(
                new EventType() { Id = 1, Name = "Casamiento" },
                new EventType() { Id = 2, Name = "Cumpleaños" },
                new EventType() { Id = 3, Name = "Bautismo" },
                new EventType() { Id = 4, Name = "Baby Shower" },
                new EventType() { Id = 5, Name = "Empresarial" },
                new EventType() { Id = 6, Name = "Fin de Año" },
                new EventType() { Id = 7, Name = "Otro Evento" }
            );
        }
    }
}
