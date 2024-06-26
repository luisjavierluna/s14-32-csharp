﻿using eventPlannerBack.Models.Entidades;
using eventPlannerBack.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventPlannerBack.Models.VModels.PostulationDTO
{
    public class PostulationDTO
    {
        public string Id { get; set; }
        public string ContractorId { get; set; }
        public Contractor Contractor { get; set; }
        public string VocationId { get; set; }
        public Vocation Vocation { get; set; } // REVER:VOCATIONS
        public string EventId { get; set; }
        public Event Event { get; set; }
        public string Message { get; set; }
        public StatusPostulation StatusPostulation { get; set; }
    }
}
