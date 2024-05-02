using eventPlannerBack.Models.Entidades;

namespace eventPlannerBack.DAL.Interfaces
{
    public interface INotificationRepository
    {
        Task<IQueryable<Notification>> GetMyNotifications(string userId);
    }
}
