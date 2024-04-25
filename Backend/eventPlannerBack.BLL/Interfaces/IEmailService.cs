using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventPlannerBack.BLL.Interfaces
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(string emailReceiver, string subject, string message);
        
    }
}
