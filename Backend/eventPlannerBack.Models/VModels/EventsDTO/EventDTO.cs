using eventPlannerBack.Models.Entidades;
using eventPlannerBack.Models.Entities;
using eventPlannerBack.Models.VModels.PostulationDTO;
using eventPlannerBack.Models.VModels.VocationDTO;

namespace eventPlannerBack.Models.VModels.EventsDTO
{
    public class EventDTO
    {
        public Guid Id { get; set; }
        public string ClientId { get; set; } = string.Empty;
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
        public List<PostulationEventDTO> postulations { get; set; } = new List<PostulationEventDTO>();
        public List<VocationDTO.VocationDTO> vocations { get; set; } = new List<VocationDTO.VocationDTO>();
        public string City { get; set; } = string.Empty;
        public string Province { get; set; } = string.Empty;        
        public string Address { get; set; } = string.Empty;
        public EventType? EventType { get; set; }
    }
}
