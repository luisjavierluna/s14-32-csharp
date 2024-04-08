﻿using eventPlannerBack.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventPlannerBack.Models.Entidades
{
    public class Event
    {
        public Guid Id { get; set; }
        public string ClientId { get; set; } = string.Empty;
        // public Client Client { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime FinishDate { get; set; }
        public StatusEvent Status { get; set; }
        public List<string> Images { get; set; } = new List<string>();
        public string PhoneNumber { get; set; } = string.Empty;
        // public List<Postulation> postulations { get; set; } = new List<Postulation>();
        // public List<Vocation> vocations { get; set; } = new List<Vocation>();
        public int CityId { get; set; }
        public City City { get; set; }
        public string Address { get; set; } = string.Empty;
    }
}