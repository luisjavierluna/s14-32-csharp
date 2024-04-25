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
                new Vocation() { Id = "02b0b46c-e514-4551-9bab-085d88ea479c", Name = "Organizador de eventos", Description = "Encargado de planificar y coordinar todos los aspectos del evento." },
                new Vocation() { Id = "18c75eca-adf7-477b-8f6c-567e77233164", Name = "Coordinador de logística", Description = "Responsable de asegurar que todos los elementos necesarios estén en su lugar y a tiempo para el evento." },
                new Vocation() { Id = "1fa63102-1c4a-449e-98f5-a0c8242d8b67", Name = "Coordinador de catering", Description = "Gestiona la comida y bebida del evento, incluyendo la contratación de servicios de catering y supervisión durante el evento." },
                new Vocation() { Id = "2487d0c0-8b1a-4e30-a08a-fc06e9268970", Name = "Diseñador gráfico", Description = "Crea materiales promocionales y de marketing para el evento, como folletos, carteles, etc." },
                new Vocation() { Id = "2b23d897-a084-4af0-b764-5a6b32d77b37", Name = "Diseñador de escenarios y decoración", Description = "Diseña y decora el espacio del evento para que sea atractivo y se ajuste al tema o estilo deseado." },
                new Vocation() { Id = "2c37cf25-e656-4760-87a5-92a4e31739be", Name = "Técnico de sonido y luces", Description = "Responsable del equipo de audio y de iluminación del evento." },
                new Vocation() { Id = "44ae6e60-bbf8-4f08-8dc0-643e589f4471", Name = "Coordinador de entretenimiento", Description = "Contrata y coordina actos de entretenimiento para el evento." },
                new Vocation() { Id = "529b09ce-79c3-4d55-a163-50b4f2e20f42", Name = "Coordinador de medios y relaciones públicas", Description = "Maneja la comunicación del evento con los medios y el público, y gestiona las redes sociales." },
                new Vocation() { Id = "5a662b07-f3c3-42fb-ac55-3696976916c5", Name = "Coordinador de seguridad", Description = "Planifica y supervisa la seguridad del evento, incluyendo la contratación de personal de seguridad." },
                new Vocation() { Id = "60e9c635-9b6d-4282-9971-cf3d1c347542", Name = "Coordinador de transporte", Description = "Coordina el transporte de los asistentes y del equipo necesario para el evento." },
                new Vocation() { Id = "7f2f955d-58db-4be9-abf2-d90efdfb8200", Name = "Coordinador de hospedaje", Description = "Coordina las reservas de hotel y asegura el alojamiento para los asistentes." },
                new Vocation() { Id = "820d0fbb-cf99-41c3-90ca-34753ac3b965", Name = "Coordinador de protocolo y relaciones institucionales", Description = "Gestiona el protocolo y las relaciones con autoridades y personalidades importantes." },
                new Vocation() { Id = "94498e27-f1f9-4e81-b481-362ba56e55ba", Name = "Fotógrafo", Description = "Captura imágenes del evento para su documentación y promoción." },
                new Vocation() { Id = "9506f13e-3901-4858-b4d7-8c5c89d68ec9", Name = "Videógrafo", Description = "Graba videos del evento para su documentación y promoción." },
                new Vocation() { Id = "9b794105-c772-40a1-907c-e46309fa8f69", Name = "Maestro de ceremonias", Description = "Conduce y anima el evento, presentando a los oradores y manteniendo el programa en marcha." },
                new Vocation() { Id = "9f6533f3-20d9-4ca6-8b87-2510ea180050", Name = "Asistente de producción", Description = "Apoya al equipo de producción en diversas tareas durante el evento." },
                new Vocation() { Id = "a2075ef7-d4a7-4011-ae97-83c1253f9746", Name = "Diseñador de experiencia de usuario (UX)", Description = "Se encarga de crear una experiencia positiva para los asistentes en términos de navegación y usabilidad." },
                new Vocation() { Id = "b878b893-2209-42e5-bf7c-c507a6fec3d9", Name = "Diseñador de experiencia de cliente (CX)", Description = "Diseña la experiencia global del cliente antes, durante y después del evento." },
                new Vocation() { Id = "b9e965e9-2352-4a7e-b4c8-6842cb6c69c7", Name = "Coordinador de voluntarios", Description = "Organiza y gestiona la participación de voluntarios en el evento." },
                new Vocation() { Id = "d78e4c8e-34ad-4cbe-b7a8-00cd12aa3425", Name = "Coordinador de limpieza y mantenimiento", Description = "Se asegura de que el lugar del evento esté limpio y en condiciones adecuadas durante todo el evento." }
                );
        }
    }
}
