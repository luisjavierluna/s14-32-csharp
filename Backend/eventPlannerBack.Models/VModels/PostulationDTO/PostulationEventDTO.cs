using eventPlannerBack.Models.Enums;
using eventPlannerBack.Models.VModels.EventsDTO;
using Microsoft.EntityFrameworkCore;
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
        [Precision(18, 2)]
        public decimal? Budget { get; set; }
    }
}
