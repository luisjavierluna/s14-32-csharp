using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eventPlannerBack.Models.Entidades.Common
{
    public abstract class BaseEntity
    {
        [Key]
        public string Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
