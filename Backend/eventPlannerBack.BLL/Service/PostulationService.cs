using eventPlannerBack.BLL.Interfaces;
using eventPlannerBack.Models.VModels.PostulationDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventPlannerBack.BLL.Service
{
    public class PostulationService : IPostulationService
    {
        public Task<PostulationCreationDTO> Create(PostulationCreationDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PostulationCreationDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<PostulationCreationDTO> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<PostulationCreationDTO> Update(string id, PostulationCreationDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
