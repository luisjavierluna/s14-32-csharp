using eventPlannerBack.Models.Entidades;
using eventPlannerBack.Models.VModels.EventsDTO;
using eventPlannerBack.Models.VModels.PostulationDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventPlannerBack.DAL.Interfaces
{
    public interface IPostulationRepository
    {
        //Task<PostulationDTO> Create(PostulationCreationDTO model);

        //Task<PostulationDTO> Update(string id, PostulationCreationDTO model);

        //Task<bool> Delete(string id);

        //Task<PostulationDTO> GetByID(string id);

        //Task<IQueryable<Postulation>> GetAll();

        Task Refuse(string id, string clientId);
        Task Accept(string id, string clientId);
        Task<IQueryable<Postulation>> GetMyPostulations(string contractorId);
    }
}
