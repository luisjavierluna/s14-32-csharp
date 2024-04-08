using eventPlannerBack.BLL.Interfaces;
using eventPlannerBack.Models.VModels.ContractorDTO;

namespace eventPlannerBack.BLL.Service
{
    public class ContractorService : IGenericService<ContractorCreationDTO, ContractorDTO>, IContractorService
    {
        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ContractorDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ContractorDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ContractorDTO> SignIn(ContractorCreationDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<ContractorDTO> Update(int id, ContractorCreationDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
