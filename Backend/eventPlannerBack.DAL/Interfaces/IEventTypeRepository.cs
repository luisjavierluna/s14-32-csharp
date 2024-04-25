using eventPlannerBack.Models.Entities;

namespace eventPlannerBack.DAL.Interfaces
{
    public interface IEventTypeRepository
    {
        Task<IQueryable<EventType>> GetEventType();
    }
}
