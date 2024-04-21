using AutoMapper;
using eventPlannerBack.BLL.Behaviors;
using eventPlannerBack.BLL.Interfaces;
using eventPlannerBack.DAL.Interfaces;
using eventPlannerBack.Models.Entidades;
using eventPlannerBack.Models.Entities;
using eventPlannerBack.Models.VModels.ContractorDTO;
using eventPlannerBack.Models.VModels.VocationDTO;
using Microsoft.EntityFrameworkCore;

namespace eventPlannerBack.BLL.Service
{
    public class ContractorService : IGenericService<ContractorCreationDTO, ContractorDTO>, IContractorService
    {
        private readonly IGenericRepository<ContractorCreationDTO, ContractorDTO, Contractor> _genericRepository;
        private readonly IContractorRepository _contractorRepository;
        private readonly IMapper _mapper;
        private readonly ValidationBehavior<ContractorCreationDTO> _validationBehavior;

        public ContractorService(
            IGenericRepository<ContractorCreationDTO, ContractorDTO, Contractor> genericRepository,
            IContractorRepository contractorRepository,
            IMapper mapper,
            ValidationBehavior<ContractorCreationDTO> validationBehavior)
        {
            _genericRepository = genericRepository;
            _contractorRepository = contractorRepository;
            _mapper = mapper;
            _validationBehavior = validationBehavior;
        }

        public async Task<bool> Delete(string id)
        {
            return await _genericRepository.Delete(id);
        }

        public async Task<IEnumerable<ContractorDTO>> GetAll()
        {
            var query = await _genericRepository.GetAll();
            var list = await query.ToListAsync();
            return _mapper.Map<IEnumerable<ContractorDTO>>(list);
        }

        public Task<ContractorDTO> GetById(string id)
        {
            return _genericRepository.GetByID(id);
        }

        public async Task<ContractorDTO> SignIn(ContractorCreationDTO model)
        {
            await _validationBehavior.ValidateFields(model);
            return await _genericRepository.Insert(model);
        }

        public async Task<ContractorsVocations> AssignVocation(AssignVocationDTO model, string contractorId)
        {
            try
            {
                ContractorsVocations contractorVocation = _mapper.Map<ContractorsVocations>(model);
                contractorVocation.ContractorId = contractorId;

                await _contractorRepository.AssignVocation(contractorVocation);
                return contractorVocation;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ContractorDTO> Update(string id, ContractorCreationDTO model)
        {
            return await _genericRepository.Update(id, model);
        }
    }
}
