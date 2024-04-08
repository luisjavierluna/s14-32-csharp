using eventPlannerBack.Models.Entidades.Common;
using eventPlannerBack.Models.Entities;

namespace eventPlannerBack.Models.Entidades
{
    public class Notification : BaseEntity
    {
        public string Title { get; set; }
        public string RedirectionLink { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
