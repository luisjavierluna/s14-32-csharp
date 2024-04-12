using AutoMapper;
using eventPlannerBack.BLL.Behaviors;
using eventPlannerBack.BLL.Interfaces;
using eventPlannerBack.DAL.Interfaces;
using eventPlannerBack.Models.Entidades;
using eventPlannerBack.Models.VModels.NotificationDTO;
using Microsoft.EntityFrameworkCore;

namespace eventPlannerBack.BLL.Service
{
    public class NotificationService : IGenericService<NotificationCreationDTO, NotificationDTO>, INotificationService
    {
        private readonly IGenericRepository<NotificationCreationDTO, NotificationDTO, Notification> _repository;
        private readonly IMapper _mapper;
        private readonly ValidationBehavior<NotificationCreationDTO> _validationBehavior;

        public NotificationService(
            IGenericRepository<NotificationCreationDTO, NotificationDTO, Notification> repository, 
            IMapper mapper,
            ValidationBehavior<NotificationCreationDTO> validationBehavior)
        {
            _repository = repository;
            _mapper = mapper;
            _validationBehavior = validationBehavior;
        }

        public async Task<bool> Delete(string id)
        {
            return await _repository.Delete(id);
        }

        public async Task<IEnumerable<NotificationDTO>> GetAll()
        {
            var query = await _repository.GetAll();
            var list = await query.ToListAsync();
            return _mapper.Map<IEnumerable<NotificationDTO>>(list);
        }

        public async Task<NotificationDTO> GetById(string id)
        {
            return await _repository.GetByID(id);
        }

        public async Task<NotificationDTO> SignIn(NotificationCreationDTO model)
        {
            await _validationBehavior.ValidateFields(model);

            return await _repository.Insert(model);
        }

        public async Task<NotificationDTO> Update(string id, NotificationCreationDTO model)
        {
            return await _repository.Update(id, model);
        }
    }
}
