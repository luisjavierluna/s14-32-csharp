using eventPlannerBack.Models.Entidades;
using eventPlannerBack.Models.Entities;
using eventPlannerBack.Models.Enums;
using eventPlannerBack.Models.VModels.ImagesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventPlannerBack.Models.VModels.EventsDTO
{
    public class EventDTO
    {
        public Guid Id { get; set; }
        public string ClientName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        // public StatusEvent Status { get; set; }
        public DateTime InitDate { get; set; }
        // public DateTime FinishDate { get; set; }
        // public List<ImageEventDTO> ImageEvents { get; set; } = new List<ImageEventDTO>();
        // public string PhoneNumber { get; set; } = string.Empty;
        public int Duration { get; set; }
        public bool IsActive { get; set; }
        public int Guests { get; set; }
        public List<Postulation> postulations { get; set; } = new List<Postulation>();
        public List<Vocation> vocations { get; set; } = new List<Vocation>();
        public City City { get; set; }
        public string Address { get; set; } = string.Empty;
    }
}
