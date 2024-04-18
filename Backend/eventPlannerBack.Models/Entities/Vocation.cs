using eventPlannerBack.Models.Entidades.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventPlannerBack.Models.Entidades
{
    public class Vocation : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Event> Events { get; set; } = new List<Event>();
        public List<Contractor> Contractors { get; set; } = new List<Contractor>();

    }
}
