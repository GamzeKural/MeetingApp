using MeetingApp.Business.Abstracts;
using MeetingApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace MeetingApp.Business.Concretes
{
    public class MailSenderService : IMailSenderService
    {
        private readonly IOptions<EmailSettings> _emailSettings;
        public MailSenderService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings;
        }
        public string SendEMail(MailModel model)
        {
            EmailSettings emailSettings = _emailSettings.Value;
            // E-posta göndermek için gerekli bilgiler
            string to = model.To;
            string subject = model.Subject;
            string body = model.Body;

            // Gönderen e-posta hesabı bilgileri
            string fromAddress = emailSettings.FromAddress;
            string password = emailSettings.Password;

            // E-posta sunucusu ayarları
            SmtpClient smtpClient = new SmtpClient(emailSettings.SmtpServer, emailSettings.Port);
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(fromAddress, password);

            // E-posta oluşturma
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(fromAddress);
            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;

            // E-postayı gönderme
            smtpClient.Send(mail);

            return "Successfull";

        }
    }
}
