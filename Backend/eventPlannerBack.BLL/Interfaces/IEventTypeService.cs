using eventPlannerBack.Models.Entities;
using eventPlannerBack.Models.VModels.CityDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventPlannerBack.BLL.Interfaces
{
    public interface IEventTypeService
    {
        Task<IEnumerable<EventType>> GetAll();
    }
}
