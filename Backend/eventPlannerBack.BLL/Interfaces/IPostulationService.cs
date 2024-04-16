using eventPlannerBack.Models.VModels.EventsDTO;
using eventPlannerBack.Models.VModels.PostulationDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventPlannerBack.BLL.Interfaces
{
    public interface IPostulationService :IGenericService<PostulationCreationDTO, PostulationDTO>
    {
        //  Se utilizó generic en su lugar
        /*
        Task<PostulationCreationDTO> Create(PostulationCreationDTO model);

        Task<PostulationCreationDTO> Update(string id, PostulationCreationDTO model);

        Task<bool> Delete(string id);

        Task<PostulationCreationDTO> GetById(string id);

        Task<IEnumerable<PostulationCreationDTO>> GetAll();
        */
    }
}
