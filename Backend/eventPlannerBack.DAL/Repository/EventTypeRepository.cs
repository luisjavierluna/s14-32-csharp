using eventPlannerBack.DAL.Dbcontext;
using eventPlannerBack.DAL.Interfaces;
using eventPlannerBack.Models.Entities;

namespace eventPlannerBack.DAL.Repository
{
    public class EventTypeRepository : IEventTypeRepository
    {
        private readonly AplicationDBcontext _dbcontext;
        public EventTypeRepository(AplicationDBcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<IQueryable<EventType>> GetEventType()
        {
            try
            {
                IQueryable<EventType> query = _dbcontext.EventTypes;
                return query;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
