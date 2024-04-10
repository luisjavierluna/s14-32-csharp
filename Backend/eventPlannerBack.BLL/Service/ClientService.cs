using AutoMapper;
using eventPlannerBack.BLL.Behaviors;
using eventPlannerBack.BLL.Interfaces;
using eventPlannerBack.DAL.Interfaces;
using eventPlannerBack.Models.Entidades;
using eventPlannerBack.Models.VModels.ClientDTO;
using Microsoft.EntityFrameworkCore;

namespace eventPlannerBack.BLL.Service
{
    public class ClientService : IGenericService<ClientCreationDTO, ClientDTO>, IClientService
    {
        private readonly IGenericRepository<ClientCreationDTO, ClientDTO, Client> _clientRepository;
        private readonly IMapper _mapper;
        private readonly ValidationBehavior<ClientCreationDTO> _validationBehavior;

        public ClientService(
            IGenericRepository<ClientCreationDTO, ClientDTO, Client> clientRepository, 
            IMapper mapper,
            ValidationBehavior<ClientCreationDTO> validationBehavior)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
            _validationBehavior = validationBehavior;
        }

        public async Task<ClientDTO> SignIn(ClientCreationDTO model)
        {
            await _validationBehavior.ValidateFields(model);
            return await _clientRepository.Insert(model);
        }

        public async Task<ClientDTO> Update(string id, ClientCreationDTO model)
        {
            return await _clientRepository.Update(id, model);
        }

        public async Task<bool> Delete(string id)
        {
            return await _clientRepository.Delete(id);
        }

        public Task<ClientDTO> GetById(string id)
        {
            return _clientRepository.GetByID(id);
        }

        public async Task<IEnumerable<ClientDTO>> GetAll()
        {
          var query = await _clientRepository.GetAll();                    
          var list = await query.ToListAsync();
            return _mapper.Map<IEnumerable<ClientDTO>>(list);
        }
       
    }

}
