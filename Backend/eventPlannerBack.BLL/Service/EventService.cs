using eventPlannerBack.BLL.Interfaces;
using eventPlannerBack.DAL.Interfaces;
using eventPlannerBack.Models.VModels.EventsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventPlannerBack.BLL.Service
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public Task<EventDTO> Create(EventCreationDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EventDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<EventDTO> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EventDTO>> GetByVocation(string vocationId)
        {
            throw new NotImplementedException();
        }

        public Task<EventDTO> Update(string id, EventCreationDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
