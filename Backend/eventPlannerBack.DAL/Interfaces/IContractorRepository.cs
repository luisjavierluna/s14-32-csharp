using eventPlannerBack.Models.Entities;

namespace eventPlannerBack.DAL.Interfaces
{
    public interface IContractorRepository
    {
        Task<ContractorsVocations> AssignVocation(ContractorsVocations model);
    }
}
