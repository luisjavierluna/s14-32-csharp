using AutoMapper;
using eventPlannerBack.BLL.Interfaces;
using eventPlannerBack.DAL.Interfaces;
using eventPlannerBack.DAL.Repository;
using eventPlannerBack.Models.VModels.CityDTO;
using eventPlannerBack.Models.VModels.EventsDTO;
using Microsoft.EntityFrameworkCore;
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
        private readonly IMapper _mapper;
        public CityService( ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProvinceDTO>> GetAllProvincies(string? filter)
        {
            try
            {
                var query = await _cityRepository.GetProvincies();
                if (filter != null) query = query.Where(p => p.Name.Contains(filter));
                var listProvinces = await query.ToListAsync();
                return _mapper.Map<List<ProvinceDTO>>(listProvinces);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<CityDTO>> GetCities(int? provinceId, string? filter)
        {
            try
            {
                var query = await _cityRepository.GetCities();
                if (provinceId != null) query = query.Where(c => c.ProvinceId == provinceId);
                if (filter != null) query = query.Where(c => c.Name.Contains(filter));
                var listCities = await query
                    .Take(20)
                    .ToListAsync();
                return _mapper.Map<List<CityDTO>>(listCities);
            }
            catch
            {
                throw;
            }
        }
    }
}
