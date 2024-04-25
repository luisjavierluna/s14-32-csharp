using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eventPlannerBack.Models.Entidades.Common
{
    public abstract class BaseEntity
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime? CreatedAt { get; set; } = DateTime.Today;
        public bool IsDeleted { get; set; } = false;
    }
}
