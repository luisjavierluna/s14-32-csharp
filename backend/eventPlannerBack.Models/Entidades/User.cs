using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace eventPlannerBack.Models.Entities
{
    public  class User: IdentityUser
    {
        
        public DateTime CreationData { get; set; }
        
        public bool Active {  get; set; } 

        public Data? Data { get; set; }

        public int? DataId { get; set; }


    }
}
