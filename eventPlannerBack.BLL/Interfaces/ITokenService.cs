using eventPlannerBack.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventPlannerBack.BLL.Interfaces
{
    public interface ITokenService
    {
        Task<string> GenerateToken(string email, int expirationDate);
    }
}
