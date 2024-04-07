using eventPlannerBack.DAL.Interfaces;
using eventPlannerBack.Models.Entidades;
using eventPlannerBack.Models.VModels.EventsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventPlannerBack.DAL.Repository
{
    public class EventRepository : IEventRepository
    {
        public Task<EventDTO> Create(EventCreationDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Event>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<EventDTO> GetByID(string id)
        {
            throw new NotImplementedException();
        }

        public Task<EventDTO> Update(string id, EventCreationDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
