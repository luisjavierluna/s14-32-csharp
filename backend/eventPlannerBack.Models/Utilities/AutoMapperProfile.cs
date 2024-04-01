using AutoMapper;
using eventPlannerBack.Models.Entities;
using eventPlannerBack.Models.VModels;
using eventPlannerBack.Models.VModels.DatosDTO;


namespace eventPlannerBack.Models.Utilities
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {                    
            
            CreateMap<DataDTO, Data>().ReverseMap();
            
            CreateMap<DataCreationDTO, Data>().ReverseMap();
                
        }
    }
}
