using eventPlannerBack.Models.Entidades;
using eventPlannerBack.Models.VModels.VocationDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventPlannerBack.DAL.Interfaces
{
    public interface IVocationRepository : IGenericRepository<VocationCreationDTO, VocationDTO, Vocation>
    {
    }
}
