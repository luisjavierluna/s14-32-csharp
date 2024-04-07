using eventPlannerBack.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventPlannerBack.DAL.Interfaces
{
    public interface ICityRepository
    {
        Task<IQueryable<City>> GetCities();
        Task<IQueryable<Province>> GetProvincies();
    }
}
