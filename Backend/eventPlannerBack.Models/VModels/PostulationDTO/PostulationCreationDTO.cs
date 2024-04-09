using eventPlannerBack.Models.Entidades;
using eventPlannerBack.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventPlannerBack.Models.VModels.PostulationDTO
{
    public class PostulationCreationDTO
    {
       
        public int ContractorId { get; set; }
        public Contractor Contractor { get; set; }
        public int VocationId { get; set; }
        public string Vocation { get; set; } // REVER:VOCATIONS
        public int EventId { get; set; }
        public Event Event { get; set; }
        public string Message { get; set; }
        public StatusPostulation StatusPostulation { get; set; }
    }
}
