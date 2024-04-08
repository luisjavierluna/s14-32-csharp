using eventPlannerBack.BLL.Interfaces;
using eventPlannerBack.Models.VModels.NotificationDTO;

namespace eventPlannerBack.BLL.Service
{
    public class NotificationService : IGenericService<NotificationCreationDTO, NotificationDTO>, INotificationService
    {
        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<NotificationDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<NotificationDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<NotificationDTO> SignIn(NotificationCreationDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<NotificationDTO> Update(int id, NotificationCreationDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
