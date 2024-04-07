using eventPlannerBack.BLL.Interfaces;
using eventPlannerBack.DAL.Interfaces;
using eventPlannerBack.Models.VModels.CitiesDTO;
using eventPlannerBack.Models.VModels.CityDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventPlannerBack.BLL.Service
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        public CityService( ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public Task<IEnumerable<CityDTO>> GetAllCities(string? filter)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProvinceDTO>> GetAllProvincies(string? filter)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CityDTO>> GetByProvince(int provinceId, string? filter)
        {
            throw new NotImplementedException();
        }
    }
}
