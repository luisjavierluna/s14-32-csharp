using eventPlannerBack.Models.Entidades;
using eventPlannerBack.Models.Entidades.Common;

namespace eventPlannerBack.Models.Entities
{
    public class ImageEvent : BaseEntity
    {
        public string Url { get; set; }
        public string EventId { get; set; }
        public Event Event { get; set; }
    }
}
