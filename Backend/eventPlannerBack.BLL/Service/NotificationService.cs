using AutoMapper;
using eventPlannerBack.BLL.Behaviors;
using eventPlannerBack.BLL.Interfaces;
using eventPlannerBack.DAL.Interfaces;
using eventPlannerBack.Models.Entidades;
using eventPlannerBack.Models.VModels.ClientDTO;
using eventPlannerBack.Models.VModels.ContractorDTO;
using eventPlannerBack.Models.VModels.NotificationDTO;
using eventPlannerBack.Models.VModels.PostulationDTO;
using Microsoft.EntityFrameworkCore;

namespace eventPlannerBack.BLL.Service
{
    public class NotificationService : IGenericService<NotificationCreationDTO, NotificationDTO>, INotificationService
    {
        private readonly IGenericRepository<NotificationCreationDTO, NotificationDTO, Notification> _genericNotificationRepository;
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;
        private readonly ValidationBehavior<NotificationCreationDTO> _validationBehavior;
        private readonly IGenericRepository<ContractorCreationDTO, ContractorDTO, Contractor> _genericContractorRepository;
        private readonly IGenericRepository<ClientCreationDTO, ClientDTO, Client> _genericClientRepository;
        private readonly IEventRepository _eventRepository;

        public NotificationService(
            IGenericRepository<NotificationCreationDTO, NotificationDTO, Notification> genericNotificationRepository,
            INotificationRepository notificationRepository,
            IMapper mapper,
            ValidationBehavior<NotificationCreationDTO> validationBehavior,
            IGenericRepository<ContractorCreationDTO, ContractorDTO, Contractor> genericContractorRepository,
            IGenericRepository<ClientCreationDTO, ClientDTO, Client> genericClientRepository,
            IEventRepository eventRepository)
        {
            _genericNotificationRepository = genericNotificationRepository;
            _notificationRepository = notificationRepository;
            _mapper = mapper;
            _validationBehavior = validationBehavior;
            _genericContractorRepository = genericContractorRepository;
            _genericClientRepository = genericClientRepository;
            _eventRepository = eventRepository;
        }

        public async Task<bool> Delete(string id)
        {
            return await _genericNotificationRepository.Delete(id);
        }

        public async Task<IEnumerable<NotificationDTO>> GetAll()
        {
            var query = await _genericNotificationRepository.GetAll();
            var list = await query.ToListAsync();
            return _mapper.Map<IEnumerable<NotificationDTO>>(list);
        }

        public async Task<IEnumerable<NotificationDTO>> GetMyNotifications(string userId)
        {
            var query = await _notificationRepository.GetMyNotifications(userId);
            var list = await query.ToListAsync();
            return _mapper.Map<IEnumerable<NotificationDTO>>(list);
        }

        public async Task<NotificationDTO> GetById(string id)
        {
            return await _genericNotificationRepository.GetByID(id);
        }

        public async Task<NotificationDTO> SignIn(NotificationCreationDTO model)
        {
            await _validationBehavior.ValidateFields(model);

            return await _genericNotificationRepository.Insert(model);
        }

        public async Task<NotificationDTO> Update(string id, NotificationCreationDTO model)
        {
            return await _genericNotificationRepository.Update(id, model);
        }

        public async Task BuildClientNotification(string eventId, string contractorId)
        {
            var eventData = await _eventRepository.GetByID(eventId);
            var contractor = await _genericContractorRepository.GetByID(contractorId);
            var client = await _genericClientRepository.GetByID(eventData.ClientId);

            NotificationCreationDTO notification = new NotificationCreationDTO()
            {
                Title = $"The contractor named {contractor.UserFirstName} {contractor.UserLastName} has applied to your event: {eventData.Name}",
                RedirectionLink = "Example Redirection Link",
                UserId = client.UserId,
            };

            await _genericNotificationRepository.Insert(notification);
        }

        public async Task BuildContractorNotification(PostulationDTO postulation, string status)
        {
            var eventData = await _eventRepository.GetByID(postulation.EventId);
            var contractor = await _genericContractorRepository.GetByID(postulation.ContractorId);

            NotificationCreationDTO notification = new NotificationCreationDTO()
            {
                Title = $"Your postulation with No. {postulation.Id} for event: {eventData.Name} has been {status}",
                RedirectionLink = "Example Redirection Link",
                UserId = contractor.UserId,
            };

            await _genericNotificationRepository.Insert(notification);
        }
    }
}
