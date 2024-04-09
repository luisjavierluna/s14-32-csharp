using eventPlannerBack.DAL.Interfaces;
using eventPlannerBack.Models.Entidades;
using eventPlannerBack.Models.VModels.NotificationDTO;

namespace eventPlannerBack.DAL.Repository
{
    public class NotificationRepository : IGenericRepository<NotificationCreationDTO, NotificationDTO, Notification>
    {
        public Task<bool> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Notification>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<NotificationDTO> GetByID(string id)
        {
            throw new NotImplementedException();
        }

        public Task<NotificationDTO> Insert(NotificationCreationDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<NotificationDTO> Update(string id, NotificationCreationDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
