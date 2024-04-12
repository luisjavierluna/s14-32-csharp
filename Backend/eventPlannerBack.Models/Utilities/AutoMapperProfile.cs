using AutoMapper;
using eventPlannerBack.Models.Entidades;
using eventPlannerBack.Models.VModels.ClientDTO;
using eventPlannerBack.Models.VModels.NotificationDTO;


namespace eventPlannerBack.Models.Utilities
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {                    
            
            CreateMap<ClientDTO, Client>().ReverseMap();
            CreateMap<ClientCreationDTO, Client>().ReverseMap();

            CreateMap<NotificationDTO, Notification>().ReverseMap();
            CreateMap<NotificationCreationDTO, Notification>().ReverseMap();

        }
    }
}
