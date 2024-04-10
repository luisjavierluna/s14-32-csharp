using eventPlannerBack.Models.Entidades;
using eventPlannerBack.Models.Enums;
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
        public DateTime FinishDate { get; set; }
        public List<string> Images { get; set; } = new List<string>();
        public string PhoneNumber { get; set; } = string.Empty;
        public List<Vocation> vocations { get; set; } = new List<Vocation>();
        public int CityId { get; set; }
        public string Address { get; set; } = string.Empty;
    }
}
