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

        Task<DTO> Update(int id, CreationDTO model);

        Task<bool> Delete(int id);

        Task<DTO> GetByID(int id);

        Task<IQueryable<Entity>> GetAll();

        
    }
}
