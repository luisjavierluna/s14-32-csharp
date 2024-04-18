using AutoMapper;
using eventPlannerBack.Models.Entidades;
using eventPlannerBack.Models.VModels.CityDTO;
using eventPlannerBack.Models.VModels.ClientDTO;
using eventPlannerBack.Models.VModels.NotificationDTO;
using eventPlannerBack.Models.VModels.EventsDTO;
using eventPlannerBack.Models.Entities;
using eventPlannerBack.Models.VModels.ImagesDTO;
using eventPlannerBack.Models.VModels.ContractorDTO;
using eventPlannerBack.Models.VModels;
using eventPlannerBack.Models.VModels.PostulationDTO;
using eventPlannerBack.Models.VModels.VocationDTO;
using eventPlannerBack.Models.Enums;

namespace eventPlannerBack.Models.Utilities
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserDTO, User>().ReverseMap();
            CreateMap<UserCreationDTO, User>().ReverseMap();

            CreateMap<ClientDTO, Client>().ReverseMap();
            CreateMap<ClientCreationDTO, Client>().ReverseMap();

            CreateMap<EventCreationDTO, Event>()
                .ForMember(e => e.vocations, dto =>
                dto.MapFrom(v => v.VocationsId.Select(id => new Vocation { Id = id })))
                .IncludeAllDerived();
            CreateMap<Event, EventDTO>()
                .ForMember(e => e.ClientName, dto => dto.MapFrom(e => e.Client.User.FirstName))
                .ForMember(e => e.vocations, dto => dto.MapFrom(e => e.vocations))
                .ForMember(e => e.City, dto => dto.MapFrom(e => e.City.Name))
                .ForMember(e => e.Province, dto => dto.MapFrom(e => e.City.Province.Name))
                .ForMember(e => e.postulations, dto => dto.MapFrom(e => e.postulations));

            CreateMap<ContractorDTO, Contractor>().ReverseMap();
            CreateMap<ContractorCreationDTO, Contractor>().ReverseMap();

            CreateMap<CityDTO, City>().ReverseMap();
            CreateMap<ProvinceDTO, Province>().ReverseMap();

            CreateMap<NotificationDTO, Notification>().ReverseMap();
            CreateMap<NotificationCreationDTO, Notification>().ReverseMap();

            CreateMap<ImageEvent, ImageEventDTO>().ReverseMap();

            CreateMap<PostulationDTO, Postulation>().ReverseMap();
            CreateMap<PostulationCreationDTO, Postulation>().ReverseMap();
            CreateMap<Postulation, PostulationEventDTO>()
                .ForMember(p => p.ContractorName, dto => dto.MapFrom(p => p.Contractor.User.FirstName))
                .ForMember(p => p.StatusPostulation, dto => dto.MapFrom(p => p.StatusPostulation.ToString()))
                .ReverseMap();

            CreateMap<VocationDTO, Vocation>().ReverseMap();
            CreateMap<VocationCreationDTO, Vocation>().ReverseMap();
        }
    }
}
