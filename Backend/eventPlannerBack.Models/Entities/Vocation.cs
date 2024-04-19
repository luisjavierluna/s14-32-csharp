using eventPlannerBack.Models.Entidades.Common;
using eventPlannerBack.Models.Entities;

namespace eventPlannerBack.Models.Entidades
{
    public class Vocation : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Event> Events { get; set; } = new List<Event>();
        public ICollection<ContractorsVocations> ContractorsVocations { get; set; } = new List<ContractorsVocations>();

    }
}
