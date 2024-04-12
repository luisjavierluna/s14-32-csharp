using AutoMapper;
using eventPlannerBack.DAL.Dbcontext;
using eventPlannerBack.DAL.Interfaces;
using eventPlannerBack.Models.Entidades;
using eventPlannerBack.Models.VModels.NotificationDTO;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace eventPlannerBack.DAL.Repository
{
    public class NotificationRepository : IGenericRepository<NotificationCreationDTO, NotificationDTO, Notification>
    {
        private readonly AplicationDBcontext _dBcontext;
        private readonly IMapper _mapper;

        public NotificationRepository(AplicationDBcontext dBcontext, IMapper mapper)
        {
            this._dBcontext = dBcontext;
            this._mapper = mapper;
        }

        public Task<bool> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IQueryable<Notification>> GetAll()
        {
            try
            {
                IQueryable<Notification> queryData = _dBcontext.Notifications;
                return queryData;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<NotificationDTO> GetByID(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<NotificationDTO> Insert(NotificationCreationDTO model)
        {
            try
            {
                var notification = _mapper.Map<Notification>(model);
                _dBcontext.Add(notification);
                await _dBcontext.SaveChangesAsync();

                return _mapper.Map<NotificationDTO>(notification);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<NotificationDTO> Update(string id, NotificationCreationDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
