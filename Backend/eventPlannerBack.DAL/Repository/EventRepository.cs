using AutoMapper;
using eventPlannerBack.API.Exceptions;
using eventPlannerBack.DAL.Dbcontext;
using eventPlannerBack.DAL.Interfaces;
using eventPlannerBack.Models.Entidades;
using eventPlannerBack.Models.Entities;
using eventPlannerBack.Models.Enums;
using eventPlannerBack.Models.VModels.EventsDTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventPlannerBack.DAL.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly AplicationDBcontext _dbcontext;
        private readonly IMapper _mapper;

        public EventRepository(AplicationDBcontext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;

        }
        public async Task<EventDTO> Create(EventCreationDTO model, string clientId)
        {
            try
            {
                var eventAdd = _mapper.Map<Event>(model);
                eventAdd.ClientId = clientId;
                eventAdd.CreatedAt = DateTime.Now;
                eventAdd.IsDeleted = false;
                eventAdd.ImageEvents = new List<ImageEvent>();
                _dbcontext.Add(eventAdd);
                await _dbcontext.SaveChangesAsync();
                return _mapper.Map<EventDTO>(eventAdd);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Delete(string id)
        {
            try
            {
                var FindEvent = await _dbcontext.Events.Where(e => e.Id == id).FirstOrDefaultAsync();
                if (FindEvent == null) throw new NotFoundException();
                FindEvent.IsDeleted = true;
                FindEvent.Status = StatusEvent.CLOSE;
                _dbcontext.Update(FindEvent);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IQueryable<Event>> GetAll()
        {
            try
            {
                IQueryable<Event> queryEvent = _dbcontext.Events;
                return queryEvent;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<EventDTO> GetByID(string id)
        {
            try
            {
                var response = await _dbcontext.Events
                    .Where(e => !e.IsDeleted)
                    .Include(e => e.City)
                        .ThenInclude(c=>c.Province)
                    .Include(e => e.vocations)
                    .Include(e => e.postulations)
                    .Include(e=>e.ImageEvents)
                    .FirstOrDefaultAsync(e => e.Id == id);
                if (response == null) throw new NotFoundException();
                return _mapper.Map<EventDTO>(response);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<EventDTO> Update(string id, EventCreationDTO model)
        {
            try
            {
                var response = await _dbcontext.Events
                    .Where(e => !e.IsDeleted)
                    .FirstOrDefaultAsync(e => e.Id == id);
                if ( response == null ) throw new NotFoundException();
                response.Name = model.Name ?? response.Name;
                response.Description = model.Description ?? response.Description;
                response.InitDate = model.InitDate ?? response.InitDate;
                response.FinishDate = model.FinishDate ?? response.FinishDate;
                response.PhoneNumber = model.PhoneNumber ?? response.PhoneNumber;
                response.CityId = model.CityId ?? response.CityId;
                response.Address = model.Address ?? response.Address;

                _dbcontext.Update(response);
                await _dbcontext.SaveChangesAsync();

                return _mapper.Map<EventDTO>(response);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
