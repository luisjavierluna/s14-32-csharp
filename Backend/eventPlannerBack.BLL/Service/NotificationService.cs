using eventPlannerBack.BLL.Interfaces;
using eventPlannerBack.Models.VModels.NotificationDTO;

namespace eventPlannerBack.BLL.Service
{
    public class NotificationService : IGenericService<NotificationCreationDTO, NotificationDTO>, INotificationService
    {
        public Task<bool> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<NotificationDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<NotificationDTO> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<NotificationDTO> SignIn(NotificationCreationDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<NotificationDTO> Update(string id, NotificationCreationDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
