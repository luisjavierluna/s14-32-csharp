using eventPlannerBack.Models.VModels.NotificationDTO;
using eventPlannerBack.Models.VModels.PostulationDTO;

namespace eventPlannerBack.BLL.Interfaces
{
    public interface INotificationService : IGenericService<NotificationCreationDTO, NotificationDTO>
    {
        Task BuildContractorNotification(PostulationDTO postulation, string status);
        Task BuildClientNotification(string eventId, string contractorId);
        Task<IEnumerable<NotificationDTO>> GetMyNotifications(string userId);
    }
}
