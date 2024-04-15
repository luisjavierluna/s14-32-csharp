using eventPlannerBack.Models.Entidades;
using eventPlannerBack.Models.Entities;
using eventPlannerBack.Models.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventPlannerBack.Models.VModels.EventsDTO
{
    public class EventCreationDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime? InitDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public List<IFormFile>? Images { get; set; } = new List<IFormFile>();
        public string PhoneNumber { get; set; } = string.Empty;
        public int? CityId { get; set; }
        public string Address { get; set; } = string.Empty;
    }
}
