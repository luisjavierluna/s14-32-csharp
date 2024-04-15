using AutoMapper;
using eventPlannerBack.API.Exceptions;
using eventPlannerBack.BLL.Behaviors;
using eventPlannerBack.BLL.Interfaces;
using eventPlannerBack.DAL.Interfaces;
using eventPlannerBack.Models.Entidades;
using eventPlannerBack.Models.Entities;
using eventPlannerBack.Models.VModels.EventsDTO;
using Microsoft.EntityFrameworkCore;

namespace eventPlannerBack.BLL.Service
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        private readonly ValidationBehavior<EventCreationDTO> _validationBehavior;
        private readonly CloudinaryService _imageService;
        private readonly IImageEventRepository _imageEventRepository;
        public EventService(IEventRepository eventRepository, IMapper mapper, ValidationBehavior<EventCreationDTO> validationBehavior, CloudinaryService imageService, IImageEventRepository imageEventRepository)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
            _validationBehavior = validationBehavior;
            _imageService = imageService;
            _imageEventRepository = imageEventRepository;
        }

        public async Task<EventDTO> Create(EventCreationDTO model, string clientId)
        {
            await _validationBehavior.ValidateFields(model);
            var eventAdd = _mapper.Map<Event>(model);
            eventAdd.ClientId = clientId;
            eventAdd.CreatedAt = DateTime.Now;
            eventAdd.IsDeleted = false;
            eventAdd.ImageEvents = new List<ImageEvent>();

            var responseEvent = await _eventRepository.Create(eventAdd, clientId);
            foreach (var image in model.Images)
            {
                var url = await _imageService.UploadImage(image);
                await _imageEventRepository.Create(new ImageEvent()
                {
                    Url = url,
                    EventId = responseEvent.Id.ToString()
                });
            }
            return responseEvent;
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
                    .Where(e => e.ClientId == id)
                    .Include(e => e.City)
                        .ThenInclude(c => c.Province)
                    .Include(e => e.vocations)
                    .Include(e => e.postulations)
                    .Include(e => e.ImageEvents)
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

        public async Task<IEnumerable<EventDTO>> GetByVocation(string vocationId)
        {
            try
            {
                var query = await _eventRepository.GetAll();
                var listEvents = query
                    .Where(e => !e.IsDeleted)
                    .Where(e => e.vocations.Where(v => v.Id == vocationId).Any())
                    .Include(e => e.City)
                        .ThenInclude(c => c.Province)
                    .Include(e => e.vocations)
                    .Include(e => e.postulations)
                    .Include(e => e.ImageEvents)
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
    }
}
