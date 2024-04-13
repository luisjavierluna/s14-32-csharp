using eventPlannerBack.Models.Entidades;
using eventPlannerBack.Models.Entidades.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventPlannerBack.Models.Entities
{
    public class ImageEvent : BaseEntity
    {
        public string Url { get; set; }
        public string EventId { get; set; }
        public Event Event { get; set; }
    }
}
