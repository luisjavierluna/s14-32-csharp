using eventPlannerBack.DAL.Interfaces;
using eventPlannerBack.Models.Entidades;
using eventPlannerBack.Models.VModels.PostulationDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventPlannerBack.DAL.Repository
{
    internal class PostulationRepository : IPostulationRepository
    {
        public Task<PostulationDTO> Create(PostulationCreationDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Postulation>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<PostulationDTO> GetByID(string id)
        {
            throw new NotImplementedException();
        }

        public Task<PostulationDTO> Update(string id, PostulationCreationDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
