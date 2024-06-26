﻿using eventPlannerBack.Models.VModels.CityDTO;
using eventPlannerBack.Models.VModels.EventsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventPlannerBack.BLL.Interfaces
{
    public interface ICityService
    {
        Task<IEnumerable<ProvinceDTO>> GetAllProvincies(string? filter);
        Task<IEnumerable<CityDTO>> GetCities(int? provinceId, string? filter);
    }
}
