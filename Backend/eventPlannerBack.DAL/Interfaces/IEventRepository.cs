using eventPlannerBack.Models.Entidades;
using eventPlannerBack.Models.VModels.EventsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventPlannerBack.DAL.Interfaces
{
    public interface IEventRepository
    {
        Task<EventDTO> Create(Event eventAdd, string clientId);

        Task<EventDTO> Update(string id, EventCreationDTO model);

        Task<bool> Delete(string id);

        Task<EventDTO> GetByID(string id);

        Task<IQueryable<Event>> GetAll();

        Task ActiveInactive(string id);
    }
}
