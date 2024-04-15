using AutoMapper;
using eventPlannerBack.API.Exceptions;
using eventPlannerBack.DAL.Dbcontext;
using eventPlannerBack.DAL.Interfaces;
using eventPlannerBack.Models.Entidades;
using eventPlannerBack.Models.VModels.NotificationDTO;
using Microsoft.EntityFrameworkCore;

namespace eventPlannerBack.DAL.Repository
{
    public class NotificationRepository : IGenericRepository<NotificationCreationDTO, NotificationDTO, Notification>
    {
        private readonly AplicationDBcontext _context;
        private readonly IMapper _mapper;

        public NotificationRepository(AplicationDBcontext dBcontext, IMapper mapper)
        {
            this._context = dBcontext;
            this._mapper = mapper;
        }

        public async Task<bool> Delete(string id)
        {
            try
            {
                var notification = await _context.Notifications.Where(c => c.Id == id).FirstOrDefaultAsync();

                if (notification == null) throw new NotFoundException();

                _context.Remove(notification);
                await _context.SaveChangesAsync();

                return true;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IQueryable<Notification>> GetAll()
        {
            try
            {
                IQueryable<Notification> queryNotifications = _context.Notifications;
                return queryNotifications;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<NotificationDTO> GetByID(string id)
        {
            var notification = await _context.Notifications.Where(c => c.Id == id).FirstOrDefaultAsync();

            if (notification == null) throw new NotFoundException();

            return _mapper.Map<NotificationDTO>(notification);
        }

        public async Task<NotificationDTO> Insert(NotificationCreationDTO model)
        {
            try
            {
                var notification = _mapper.Map<Notification>(model);
                _context.Add(notification);
                await _context.SaveChangesAsync();

                return _mapper.Map<NotificationDTO>(notification);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<NotificationDTO> Update(string id, NotificationCreationDTO model)
        {
            try
            {
                var notification = await _context.Notifications.Where(c => c.Id == id).FirstOrDefaultAsync();

                if (notification == null) throw new NotFoundException();

                notification.Title = model.Title;
                notification.RedirectionLink = model.RedirectionLink;
                notification.UserId = model.UserId;

                _context.Update(notification);
                await _context.SaveChangesAsync();

                return _mapper.Map<NotificationDTO>(notification);

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
