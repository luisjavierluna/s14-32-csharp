using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventPlannerBack.Models.Entities
{
    public class Data
    {
       
        public int Id { get; set; }

        [MaxLength(45)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(45)]
        public string Surname { get; set; } = string.Empty;
        
        [MaxLength(250)]
        public string Adress { get; set; } = string.Empty;              
        
        [MaxLength(45)]
        public string DNI { get; set; } = string.Empty;

        [MaxLength(250)]
        public string Phone { get; set; } = string.Empty;



    }
}
