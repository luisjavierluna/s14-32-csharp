using eventPlannerBack.Models.Entidades.Common;
using eventPlannerBack.Models.Entities;

namespace eventPlannerBack.Models.Entidades
{
    public class Contractor : BaseEntity
    {
        public User User { get; set; }
        public string? CUIT { get; set; }
        public List<Vocation> ListContractorVocations { get; set; } = new List<Vocation>();
        public ICollection<Postulation> Postulations { get; set; }
    }
}
