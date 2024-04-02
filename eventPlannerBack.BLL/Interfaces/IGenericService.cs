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

        Task<DTO> Update(int id, CreationDTO model);

        Task<bool> Delete(int id);

        Task<DTO> GetById(int id);

        Task<IEnumerable<DTO>> GetAll();
    }
}
