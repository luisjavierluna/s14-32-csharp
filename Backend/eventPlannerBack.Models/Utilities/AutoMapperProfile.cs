using AutoMapper;
using eventPlannerBack.Models.Entidades;
using eventPlannerBack.Models.VModels.CityDTO;
using eventPlannerBack.Models.VModels.ClientDTO;
using eventPlannerBack.Models.VModels.NotificationDTO;
using eventPlannerBack.Models.VModels.EventsDTO;


namespace eventPlannerBack.Models.Utilities
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<ClientDTO, Client>().ReverseMap();
            CreateMap<ClientCreationDTO, Client>().ReverseMap();

            CreateMap<EventCreationDTO, Event>().ReverseMap();
            CreateMap<EventDTO, Event>().ReverseMap();

            CreateMap<CityDTO, City>().ReverseMap();
            CreateMap<ProvinceDTO, Province>().ReverseMap();

            CreateMap<NotificationDTO, Notification>().ReverseMap();
            CreateMap<NotificationCreationDTO, Notification>().ReverseMap();

        }
    }
}
