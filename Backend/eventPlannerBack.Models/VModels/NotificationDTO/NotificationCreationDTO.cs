using eventPlannerBack.Models.Entities;

namespace eventPlannerBack.Models.VModels.NotificationDTO
{
    public class NotificationCreationDTO
    {
        public string Title { get; set; }
        public string RedirectionLink { get; set; }
        public string UserId { get; set; }
    }
}
