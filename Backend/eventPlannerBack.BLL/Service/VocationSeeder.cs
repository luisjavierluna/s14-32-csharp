using eventPlannerBack.BLL.Interfaces;
using eventPlannerBack.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eventPlannerBack.Models.VModels.VocationDTO;

namespace eventPlannerBack.BLL.Service
{
    public class VocationSeeder : IVocationSeeder
    {
        private readonly IVocationRepository _vocationRepository;


        public VocationSeeder(IVocationRepository vocationRepository)
        {
            _vocationRepository = vocationRepository;
        }

        public async Task CreateVocations()
        {
             List<VocationCreationDTO> vocations = new List<VocationCreationDTO>{
                new VocationCreationDTO(){Name="Planificador de eventos",Description="El planificador de eventos coordina todos los aspectos del evento, desde la ubicación hasta la logística, asegurando que todo salga según lo planeado."},
                new VocationCreationDTO(){Name="Decorador de eventos",Description="El decorador de eventos es experto en diseño de interiores y decoración, creando ambientes impresionantes para cualquier ocasión." },
                new VocationCreationDTO(){Name="Fotógrafo y videógrafo", Description="El fotógrafo y videógrafo captura los momentos especiales del evento para que puedan ser recordados y compartidos en el futuro." },
                new VocationCreationDTO(){Name="Coordinador de logística y transporte",Description="" },//"El coordinador de logística y transporte asegura que todos los elementos necesarios para el evento estén en su lugar a tiempo y coordina el transporte si es necesario." },
                new VocationCreationDTO(){Name="Especialista en relaciones públicas y marketing" }//,Description ="El especialista en relaciones públicas y marketing promociona el evento, asegurando una buena asistencia y cobertura mediática si es necesario." }
            };
            
            var query = await _vocationRepository.GetAll();           

            foreach (var vocation in vocations)
            {
                try
                {
                    var vocationExist = await query.Where(x => x.Name == vocation.Name).FirstOrDefaultAsync();
                    if (vocationExist == null) await _vocationRepository.Insert(vocation);

                }
                catch (Exception)
                {
                    throw;
                }
            }
       
        }
    }
}
