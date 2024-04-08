using AutoMapper;
using eventPlannerBack.Models.Entidades;
using eventPlannerBack.Models.VModels.ClientDTO;


namespace eventPlannerBack.Models.Utilities
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {                    
            
            CreateMap<ClientDTO, Client>().ReverseMap();
            
            CreateMap<ClientCreationDTO, Client>().ReverseMap();
                
        }
    }
}
