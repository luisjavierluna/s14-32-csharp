using eventPlannerBack.Models.Entidades.Common;
using eventPlannerBack.Models.Entities;

namespace eventPlannerBack.Models.Entidades
{
    public class Contractor : BaseEntity
    {
        public User User { get; set; }
        public string? CUIT { get; set; }
        public ICollection<ContractorsVocations> ContractorsVocations { get; } = new List<ContractorsVocations>();
        public ICollection<Postulation> Postulations { get; set; }
    }
}
