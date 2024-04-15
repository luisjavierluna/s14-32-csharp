using eventPlannerBack.Models.Entidades.Common;
using eventPlannerBack.Models.Entities;
using eventPlannerBack.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventPlannerBack.Models.Entidades
{
    public class Event : BaseEntity
    {
        public string ClientId { get; set; } = string.Empty;
        public Client Client { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime InitDate { get; set; }
        public DateTime FinishDate { get; set; }
        public StatusEvent Status { get; set; }
        public List<ImageEvent> ImageEvents { get; set; } = new List<ImageEvent>();
        public string PhoneNumber { get; set; } = string.Empty;
        public List<Postulation> postulations { get; set; } = new List<Postulation>();
        public List<Vocation> vocations { get; set; } = new List<Vocation>();
        public int CityId { get; set; }
        public City City { get; set; }
        public string Address { get; set; } = string.Empty;
    }
}
