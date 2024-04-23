using AutoMapper;
using eventPlannerBack.BLL.Interfaces;
using eventPlannerBack.DAL.Interfaces;
using eventPlannerBack.DAL.Repository;
using eventPlannerBack.Models.Entities;
using eventPlannerBack.Models.VModels.CityDTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventPlannerBack.BLL.Service
{
    public class EventTypeService : IEventTypeService
    {
        private readonly IEventTypeRepository _eventTypeRepository;
        public EventTypeService(IEventTypeRepository eventTypeRepository)
        {
            _eventTypeRepository = eventTypeRepository;
        }

        public async Task<IEnumerable<EventType>> GetAll()
        {
            try
            {
                var query = await _eventTypeRepository.GetEventType();
                var listEventTypes = await query.ToListAsync();
                return listEventTypes;
            }
            catch
            {
                throw;
            }
        }
    }
}
