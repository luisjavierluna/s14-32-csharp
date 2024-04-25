using eventPlannerBack.DAL.Dbcontext;
using eventPlannerBack.DAL.Interfaces;
using eventPlannerBack.Models.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventPlannerBack.DAL.Repository
{
    public class CityRepository : ICityRepository
    {
        private readonly AplicationDBcontext _dbcontext;
        public CityRepository(AplicationDBcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<IQueryable<City>> GetCities()
        {
            try
            {
                IQueryable<City> queryCity = _dbcontext.Cities;
                return queryCity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IQueryable<Province>> GetProvincies()
        {
            try
            {
                IQueryable<Province> queryProvince = _dbcontext.Provinces;
                return queryProvince;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
