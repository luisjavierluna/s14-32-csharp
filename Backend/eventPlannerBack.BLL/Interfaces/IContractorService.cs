using eventPlannerBack.Models.Entities;
using eventPlannerBack.Models.VModels.ContractorDTO;
using eventPlannerBack.Models.VModels.VocationDTO;

namespace eventPlannerBack.BLL.Interfaces
{
    public interface IContractorService : IGenericService<ContractorCreationDTO, ContractorDTO>
    {
        Task<ContractorsVocations> AssignVocation(AssignVocationDTO model, string contractorId);
    }
}
