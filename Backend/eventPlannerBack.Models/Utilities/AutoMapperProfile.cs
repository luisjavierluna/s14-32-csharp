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

            CreateMap<EventCreationDTO, Event>().ReverseMap().IncludeAllDerived();
            CreateMap<EventDTO, Event>().ReverseMap().IncludeAllDerived();

            CreateMap<ContractorDTO, Contractor>().ReverseMap();
            CreateMap<ContractorCreationDTO, Contractor>().ReverseMap();

            CreateMap<CityDTO, City>().ReverseMap();
            CreateMap<ProvinceDTO, Province>().ReverseMap();

            CreateMap<NotificationDTO, Notification>().ReverseMap();
            CreateMap<NotificationCreationDTO, Notification>().ReverseMap();

            CreateMap<ImageEvent, ImageEventDTO>().ReverseMap();
        }
    }
}
