using eventPlannerBack.Models.VModels.VocationDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventPlannerBack.BLL.Interfaces
{
    public interface IVocationService:IGenericService<VocationCreationDTO, VocationDTO> 
    {
    }
}
