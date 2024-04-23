using eventPlannerBack.Models.Enums;
using eventPlannerBack.Models.VModels.EventsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventPlannerBack.Models.VModels.PostulationDTO
{
    public class PostulationEventDTO
    {
        public string Id { get; set; }
        public string ContractorId { get; set; } = string.Empty;
        public string ContractorName { get; set; } = string.Empty;
        public string VocationId { get; set; }
        public string VocationName { get; set; }
        public string StatusPostulation { get; set; }
        public double subprice { get; set; }
    }
}
