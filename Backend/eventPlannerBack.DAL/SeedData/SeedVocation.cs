using eventPlannerBack.Models.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventPlannerBack.DAL.SeedData
{
    public class SeedVocation
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vocation>().HasData(
                new Vocation() { Id = Guid.NewGuid().ToString(), Name = "Organizador de eventos", Description = "Encargado de planificar y coordinar todos los aspectos del evento." },
                new Vocation() { Id = Guid.NewGuid().ToString(), Name = "Coordinador de logística", Description = "Responsable de asegurar que todos los elementos necesarios estén en su lugar y a tiempo para el evento." },
                new Vocation() { Id = Guid.NewGuid().ToString(), Name = "Coordinador de catering", Description = "Gestiona la comida y bebida del evento, incluyendo la contratación de servicios de catering y supervisión durante el evento." },
                new Vocation() { Id = Guid.NewGuid().ToString(), Name = "Diseñador gráfico", Description = "Crea materiales promocionales y de marketing para el evento, como folletos, carteles, etc." },
                new Vocation() { Id = Guid.NewGuid().ToString(), Name = "Diseñador de escenarios y decoración", Description = "Diseña y decora el espacio del evento para que sea atractivo y se ajuste al tema o estilo deseado." },
                new Vocation() { Id = Guid.NewGuid().ToString(), Name = "Técnico de sonido y luces", Description = "Responsable del equipo de audio y de iluminación del evento." },
                new Vocation() { Id = Guid.NewGuid().ToString(), Name = "Coordinador de entretenimiento", Description = "Contrata y coordina actos de entretenimiento para el evento." },
                new Vocation() { Id = Guid.NewGuid().ToString(), Name = "Coordinador de medios y relaciones públicas", Description = "Maneja la comunicación del evento con los medios y el público, y gestiona las redes sociales." },
                new Vocation() { Id = Guid.NewGuid().ToString(), Name = "Coordinador de seguridad", Description = "Planifica y supervisa la seguridad del evento, incluyendo la contratación de personal de seguridad." },
                new Vocation() { Id = Guid.NewGuid().ToString(), Name = "Coordinador de transporte", Description = "Coordina el transporte de los asistentes y del equipo necesario para el evento." },
                new Vocation() { Id = Guid.NewGuid().ToString(), Name = "Coordinador de hospedaje", Description = "Coordina las reservas de hotel y asegura el alojamiento para los asistentes." },
                new Vocation() { Id = Guid.NewGuid().ToString(), Name = "Coordinador de protocolo y relaciones institucionales", Description = "Gestiona el protocolo y las relaciones con autoridades y personalidades importantes." },
                new Vocation() { Id = Guid.NewGuid().ToString(), Name = "Fotógrafo", Description = "Captura imágenes del evento para su documentación y promoción." },
                new Vocation() { Id = Guid.NewGuid().ToString(), Name = "Videógrafo", Description = "Graba videos del evento para su documentación y promoción." },
                new Vocation() { Id = Guid.NewGuid().ToString(), Name = "Maestro de ceremonias", Description = "Conduce y anima el evento, presentando a los oradores y manteniendo el programa en marcha." },
                new Vocation() { Id = Guid.NewGuid().ToString(), Name = "Asistente de producción", Description = "Apoya al equipo de producción en diversas tareas durante el evento." },
                new Vocation() { Id = Guid.NewGuid().ToString(), Name = "Diseñador de experiencia de usuario (UX)", Description = "Se encarga de crear una experiencia positiva para los asistentes en términos de navegación y usabilidad." },
                new Vocation() { Id = Guid.NewGuid().ToString(), Name = "Diseñador de experiencia de cliente (CX)", Description = "Diseña la experiencia global del cliente antes, durante y después del evento." },
                new Vocation() { Id = Guid.NewGuid().ToString(), Name = "Coordinador de voluntarios", Description = "Organiza y gestiona la participación de voluntarios en el evento." },
                new Vocation() { Id = Guid.NewGuid().ToString(), Name = "Coordinador de limpieza y mantenimiento", Description = "Se asegura de que el lugar del evento esté limpio y en condiciones adecuadas durante todo el evento." }
                );
        }
    }
}
