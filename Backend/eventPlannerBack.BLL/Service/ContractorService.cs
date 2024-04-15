using AutoMapper;
using eventPlannerBack.BLL.Behaviors;
using eventPlannerBack.BLL.Interfaces;
using eventPlannerBack.DAL.Interfaces;
using eventPlannerBack.Models.Entidades;
using eventPlannerBack.Models.VModels.ContractorDTO;
using Microsoft.EntityFrameworkCore;

namespace eventPlannerBack.BLL.Service
{
    public class ContractorService : IGenericService<ContractorCreationDTO, ContractorDTO>, IContractorService
    {
        private readonly IGenericRepository<ContractorCreationDTO, ContractorDTO, Contractor> _contractorRepository;
        private readonly IMapper _mapper;
        private readonly ValidationBehavior<ContractorCreationDTO> _validationBehavior;

        public ContractorService(
            IGenericRepository<ContractorCreationDTO, ContractorDTO, Contractor> contractorRepository,
            IMapper mapper,
            ValidationBehavior<ContractorCreationDTO> validationBehavior)
        {
            _contractorRepository = contractorRepository;
            _mapper = mapper;
            _validationBehavior = validationBehavior;
        }

        public async Task<bool> Delete(string id)
        {
            return await _contractorRepository.Delete(id);
        }

        public async Task<IEnumerable<ContractorDTO>> GetAll()
        {
            var query = await _contractorRepository.GetAll();
            var list = await query.ToListAsync();
            return _mapper.Map<IEnumerable<ContractorDTO>>(list);
        }

        public Task<ContractorDTO> GetById(string id)
        {
            return _contractorRepository.GetByID(id);
        }

        public async Task<ContractorDTO> SignIn(ContractorCreationDTO model)
        {
            await _validationBehavior.ValidateFields(model);
            return await _contractorRepository.Insert(model);
        }

        public async Task<ContractorDTO> Update(string id, ContractorCreationDTO model)
        {
            return await _contractorRepository.Update(id, model);
        }
    }
}
