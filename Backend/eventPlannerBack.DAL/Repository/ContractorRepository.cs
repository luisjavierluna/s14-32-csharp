using eventPlannerBack.DAL.Interfaces;
using eventPlannerBack.Models.Entidades;
using eventPlannerBack.Models.VModels.ContractorDTO;

namespace eventPlannerBack.DAL.Repository
{
    public class ContractorRepository : IGenericRepository<ContractorCreationDTO, ContractorDTO, Contractor>
    {
        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Contractor>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ContractorDTO> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ContractorDTO> Insert(ContractorCreationDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<ContractorDTO> Update(int id, ContractorCreationDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
