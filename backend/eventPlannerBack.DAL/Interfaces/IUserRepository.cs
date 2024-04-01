using eventPlannerBack.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventPlannerBack.DAL.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> SignIn(User modelo, string password);

        Task<bool> UpdateByDataId(int datosId, string email);

        Task<User> GetByEmailAsync(string email);


    }
}
