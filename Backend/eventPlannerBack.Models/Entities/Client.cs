using eventPlannerBack.Models.Entidades.Common;
using eventPlannerBack.Models.Entities;

namespace eventPlannerBack.Models.Entidades
{
    public class Client : BaseEntity
    {
        public User User { get; set; }
        public string? DNI { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}
