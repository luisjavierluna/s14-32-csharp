using eventPlannerBack.BLL.Interfaces;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit.Text;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;

namespace eventPlannerBack.BLL.Service
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration configuration;
        public EmailService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<bool> SendEmailAsync(string mailReceiver, string task, string message)
        {

            try
            {
                var email = new MimeMessage();

                email.From.Add(new MailboxAddress("EventPlanner", configuration["Email:UserName"]));


                email.To.Add(MailboxAddress.Parse(mailReceiver));

                email.Subject = task;

                email.Body = new TextPart(TextFormat.Html)
                {
                    Text = message
                };


                using (var smtp = new SmtpClient())
                {

                    await smtp.ConnectAsync(configuration["Email:Host"], int.Parse(configuration["Email:Port"]!), SecureSocketOptions.StartTls);

                    await smtp.AuthenticateAsync(configuration["Email:UserName"], configuration["Email:PassWord"]);

                    await smtp.SendAsync(email);

                    await smtp.DisconnectAsync(true);
                } ;


                return true;
            }
            catch (Exception)
            {

                return false;
            }


        }    
        
    }
}
