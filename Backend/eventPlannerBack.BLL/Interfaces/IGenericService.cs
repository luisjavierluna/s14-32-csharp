using eventPlannerBack.Models.Entities;
using eventPlannerBack.Models.VModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventPlannerBack.BLL.Interfaces
{
    public interface IGenericService<CreationDTO,DTO>
    {
        Task<DTO> SignIn(CreationDTO model);

        Task<DTO> Update(string id, CreationDTO model);

        Task<bool> Delete(string id);

        Task<DTO> GetById(string id);

        Task<IEnumerable<DTO>> GetAll();
    }
}
