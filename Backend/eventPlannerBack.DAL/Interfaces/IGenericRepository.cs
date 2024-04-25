using eventPlannerBack.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventPlannerBack.DAL.Interfaces
{
    public interface IGenericRepository<CreationDTO,DTO, Entity> 
    {
        Task<DTO> Insert(CreationDTO model);

        Task<DTO> Update(string id, CreationDTO model);

        Task<bool> Delete(string id);

        Task<DTO> GetByID(string id);

        Task<IQueryable<Entity>> GetAll();
    }
}
