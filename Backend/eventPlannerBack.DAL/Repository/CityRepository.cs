using eventPlannerBack.DAL.Interfaces;
using eventPlannerBack.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventPlannerBack.DAL.Repository
{
    public class CityRepository : ICityRepository
    {
        public Task<IQueryable<City>> GetCities()
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Province>> GetProvincies()
        {
            throw new NotImplementedException();
        }
    }
}
