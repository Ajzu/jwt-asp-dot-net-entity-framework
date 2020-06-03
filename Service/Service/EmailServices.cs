using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Service.Service
{
    public class EmailServices
    {
        public async Task SendEmailAsync(string email, string subject, string body)
        {
            MailMessage message = new MailMessage();
            message.IsBodyHtml = true;
            message.From = new MailAddress(SMTP.From, SMTP.Fromname);
            message.To.Add(new MailAddress(email));
            message.Subject = subject;
            message.Body = body;

            using (var client = new SmtpClient(SMTP.Host, SMTP.Port))
            {
                // Pass SMTP credentials
                client.Credentials = new NetworkCredential(SMTP.Username, SMTP.Password);

                // Enable SSL encryption
                client.EnableSsl = true;
                await client.SendMailAsync(message);
            }
        }

    }
}
