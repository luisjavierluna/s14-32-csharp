using eventPlannerBack.Models.Entidades.Common;
using eventPlannerBack.Models.Entities;

namespace eventPlannerBack.Models.Entidades
{
    public class Client : BaseEntity
    {
        public User User { get; set; }
        public string TaxCode { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}
