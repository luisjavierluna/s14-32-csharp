using eventPlannerBack.Models.VModels.EventsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventPlannerBack.BLL.Interfaces
{
    public interface IEventService
    {
        Task<EventDTO> Create(EventCreationDTO model, string clientId);

        Task<EventDTO> Update(string id, EventCreationDTO model);

        Task<bool> Delete(string id);

        Task<EventDTO> GetById(string id);

        Task<IEnumerable<EventDTO>> GetMyEvents(string id);
        Task<IEnumerable<EventDTO>> GetByVocation(string vocationId);
    }
}
