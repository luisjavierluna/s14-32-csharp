using Microsoft.EntityFrameworkCore;

namespace eventPlannerBack.Models.VModels.PostulationDTO
{
    public class PostulationCreationDTO
    {
       
        public string? ContractorId { get; set; }
        //public Contractor Contractor { get; set; }
        public string VocationId { get; set; } // TEMPORAL
        //public Vocation Vocation { get; set; } // REVER:VOCATIONS
        public string EventId { get; set; } // TEMPORAL
        //public Event Event { get; set; }
        public string? Message { get; set; }
        [Precision(18, 2)]
        public decimal? Budget { get; set; }
    }
}
