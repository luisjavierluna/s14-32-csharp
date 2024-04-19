using eventPlannerBack.Models.Entidades;

namespace eventPlannerBack.Models.Entities
{
    public class ContractorsVocations
    {
        public string ContractorId { get; set; }
        public string VocationId { get; set; }
        public Contractor Contractor { get; set; }
        public Vocation Vocation { get; set; }
    }
}
