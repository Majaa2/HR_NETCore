using System;
using HR.WebApi.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Text;
using HR.Model.Helpers;

namespace HR.WebApi.Helpers
{
    public class Email : IEmail
    {
        private readonly EmailConfiguration emailConfiguration;

        public Email(EmailConfiguration emailConfiguration)
        {
            this.emailConfiguration = emailConfiguration;
        }
        public bool Send(string[] to, string subject, string body, bool isHtml)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(emailConfiguration.UserName);
            mailMessage.Subject = subject;
            mailMessage.Body = body;
            mailMessage.IsBodyHtml = isHtml;

            foreach (var item in to)
            {
                mailMessage.To.Add(item);
            }

            using (SmtpClient smtpClient = new SmtpClient(emailConfiguration.SmtpServer, emailConfiguration.Port))
            {
                smtpClient.Credentials = new System.Net.NetworkCredential()
                {
                    UserName = emailConfiguration.UserName,
                    Password = emailConfiguration.Password
                };

                smtpClient.EnableSsl = emailConfiguration.IsSsl;
                smtpClient.Send(mailMessage);
            }


            return true;
        }
    }
}
