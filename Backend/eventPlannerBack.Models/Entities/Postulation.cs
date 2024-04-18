using eventPlannerBack.Models.Entidades.Common;
using eventPlannerBack.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventPlannerBack.Models.Entidades
{
    public class Postulation : BaseEntity
    {
        public string? ContractorId { get; set; } // TEMPORALMENTE PUEDEN SER NULOS
        public Contractor Contractor { get; set; }
        public string? VocationId { get; set; } // TEMPORALMENTE PUEDEN SER NULOS
        public Vocation Vocation { get; set; } // REVER:VOCATIONS
        public string? EventId { get; set; } // TEMPORALMENTE PUEDEN SER NULOS
        public Event Event { get; set; }
        public string Message { get;set; }
        public StatusPostulation StatusPostulation { get; set; }

    }
}
