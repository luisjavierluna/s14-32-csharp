﻿using AutoMapper;
using eventPlannerBack.API.Exceptions;
using eventPlannerBack.BLL.Behaviors;
using eventPlannerBack.BLL.Interfaces;
using eventPlannerBack.DAL.Dbcontext;
using eventPlannerBack.DAL.Interfaces;
using eventPlannerBack.Models.Entidades;
using eventPlannerBack.Models.Entities;
using eventPlannerBack.Models.Enums;
using eventPlannerBack.Models.VModels.EventsDTO;
using Microsoft.EntityFrameworkCore;

namespace eventPlannerBack.BLL.Service
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        private readonly ValidationBehavior<EventCreationDTO> _validationBehavior;
        private readonly AplicationDBcontext _dbcontext;
        // private readonly CloudinaryService _imageService;
        // private readonly IImageEventRepository _imageEventRepository;
        public EventService(IEventRepository eventRepository, IMapper mapper, ValidationBehavior<EventCreationDTO> validationBehavior, AplicationDBcontext dbcontext/*, CloudinaryService imageService, IImageEventRepository imageEventRepository*/)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
            _validationBehavior = validationBehavior;
            _dbcontext = dbcontext;
            // _imageService = imageService;
            // _imageEventRepository = imageEventRepository;
        }

        public async Task<EventDTO> Create(EventCreationDTO model, string clientId)
        {
            await _validationBehavior.ValidateFields(model);
            return await _eventRepository.Create(model, clientId);
        }

        public async Task<bool> Delete(string id)
        {
            return await _eventRepository.Delete(id);
        }

        public async Task<IEnumerable<EventDTO>> GetMyEvents(string id)
        {
            try
            {
                var query = await _eventRepository.GetAll();
                var listEvents = await query
                    .Where(e => !e.IsDeleted)
                    .Where(e => e.IsActive)
                    .Where(e => e.ClientId == id)
                    .Include(e => e.City)
                        .ThenInclude(c => c.Province)
                    .Include(e => e.vocations)
                    .Include(e => e.postulations.Where(p=>p.StatusPostulation!=StatusPostulation.REFUSED))
                        .ThenInclude(p=>p.Contractor).ThenInclude(c => c.User)
                    .Include(e => e.Client).ThenInclude(c=>c.User)
                    .Include(e=>e.EventType)
                    //.Include(e => e.ImageEvents)
                    .ToListAsync();
                return _mapper.Map<List<EventDTO>>(listEvents);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<EventDTO>> GetMyInactiveEvents(string id)
        {
            try
            {
                var query = await _eventRepository.GetAll();
                var listEvents = await query
                    .Where(e => !e.IsDeleted)
                    .Where(e => !e.IsActive)
                    .Where(e => e.ClientId == id)
                    .Include(e => e.City)
                        .ThenInclude(c => c.Province)
                    .Include(e => e.vocations)
                    .Include(e => e.postulations.Where(p => p.StatusPostulation != StatusPostulation.REFUSED))
                        .ThenInclude(p => p.Contractor).ThenInclude(c => c.User)
                    .Include(e => e.Client).ThenInclude(c => c.User)
                    .Include(e => e.EventType)
                    //.Include(e => e.ImageEvents)
                    .ToListAsync();
                return _mapper.Map<List<EventDTO>>(listEvents);
            }
            catch
            {
                throw;
            }
        }

        public async Task<EventDTO> GetById(string id)
        {
            return await _eventRepository.GetByID(id);
        }

        public async Task<IEnumerable<EventDTO>> GetByVocation(string contractorId, string clientId, int? eventTypeId)
        {
            try
            {
                var contractor = await _dbcontext.Contractors.Where(c => c.Id == contractorId)
                    .Include(c=>c.ContractorsVocations).ThenInclude(c=>c.Vocation)
                    .FirstOrDefaultAsync();
                List<string> vocationsId = new List<string>();
                if (contractor != null) 
                { 
                    foreach (var con in contractor.ContractorsVocations)
                    {
                        vocationsId.Add(con.Vocation.Id);
                    }
                }

                var query = await _eventRepository.GetAll();
                if (eventTypeId.HasValue) query = query.Where(e=>e.EventTypeId == eventTypeId);
                var listEvents = await query
                    .Where(e => !e.IsDeleted)
                    .Where(e => e.IsActive)
                    .Where(e => e.vocations.Where(v =>vocationsId.Contains(v.Id)).Any())
                    .Where(e=>e.Client.Id != clientId)
                    .Include(e => e.City)
                        .ThenInclude(c => c.Province)
                    .Include(e => e.vocations)
                    .Include(e => e.Client).ThenInclude(c => c.User)
                    .Include(e => e.EventType)
                    //.Include(e => e.ImageEvents)
                    .ToListAsync();
                return _mapper.Map<List<EventDTO>>(listEvents);
            }
            catch
            {
                throw;
            }
        }

        public async Task<EventDTO> Update(string id, EventCreationDTO model)
        {
            return await _eventRepository.Update(id, model);
        }

        public async Task ActiveInactive(string id)
        {
            await _eventRepository.ActiveInactive(id);
        }
    }
}
