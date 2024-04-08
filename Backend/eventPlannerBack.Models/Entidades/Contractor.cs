using eventPlannerBack.Models.Entidades.Common;
using eventPlannerBack.Models.Entities;

namespace eventPlannerBack.Models.Entidades
{
    public class Contractor : BaseEntity
    {
        public User User { get; set; }
        public string CUIT { get; set; }
        //public ICollection<Vocation> Vocations { get; set; }
        //public ICollection<Postulation> Postulations { get; set; }
    }
}
