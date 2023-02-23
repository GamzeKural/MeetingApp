using MeetingApp.Business.Abstracts;
using MeetingApp.Business.Utils;
using MeetingApp.DataAccess.Abstracts;
using MeetingApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MeetingApp.Business.Concretes
{
    public class EmailService : IEmailService
    {
        private readonly IRepository _repo;
        private readonly IMailSenderService _mailSenderService;
        private readonly IEmailRecipientService emailRecipientService;
        public EmailService(IRepository repo, IMailSenderService mailSenderService, IEmailRecipientService emailRecipientService)
        {
            _repo = repo;
            _mailSenderService = mailSenderService;
            this.emailRecipientService = emailRecipientService;
        }
        public OperationResponse<Email> AddEmail(Email email)
        {
            try
            {
                var newEmail = new Email();
                var result = new OperationResponse<Email>();
                newEmail = email;

                var sendingMail = new MailModel();
                sendingMail.Subject = newEmail.Subject;
                sendingMail.Body = newEmail.Body;

                //foreach (var user in users)
                //{
                //    newEmail.EmailRecipients.Add(new EmailRecipient() { UserId = user.Id, EmailId = newEmail.Id });
                //}

                List<EmailRecipient> recipients = new List<EmailRecipient>();

                recipients = newEmail.EmailRecipients.ToList();

                newEmail.EmailRecipients = new List<EmailRecipient>();

                _repo.Add(newEmail);
                _repo.SaveChanges();

                foreach (var recipient in recipients)
                {
                    recipient.EmailId = newEmail.Id;
                    emailRecipientService.AddEmailRecipient(recipient);

                    var userMail = _repo.Get<User>(recipient.UserId).Mail;

                    sendingMail.To += userMail + ",";
                }

                sendingMail.To =  sendingMail.To.TrimEnd(',');

                _mailSenderService.SendEMail(sendingMail);

                result = OperationResponse<Email>.CreateSuccesResponse(email);
                result.Message = "Successfully added.";

                return result;
            }
            catch (Exception ex)
            {
                return OperationResponse<Email>.CreateFailure(ex.Message);
            }
        }

        public OperationResponse<List<Email>> GetAllEmails()
        {
            try
            {
                var emails = _repo.GetAll<Email>().ToList();

                var result = OperationResponse<List<Email>>.CreateSuccesResponse(emails);

                result.Message = "Successfully brought.";

                return result;
            }
            catch (Exception ex)
            {
                return OperationResponse<List<Email>>.CreateFailure(ex.Message);
            }
        }
       
        public OperationResponse<Email> GetEmail(int id)
        {
            try
            {
                var email = _repo.Get<Email>(id);

                var result = OperationResponse<Email>.CreateSuccesResponse(email);

                result.Message = "Successfully brought.";

                return result;
            }
            catch (Exception ex)
            {
                return OperationResponse<Email>.CreateFailure(ex.Message);
            }
        }

        public OperationResponse<int> RemoveEmail(int id)
        {
            try
            {
                var email = _repo.Get<Email>(id);
                _repo.Remove(email);
                var response = _repo.SaveChanges();
                var result = OperationResponse<int>.CreateSuccesResponse(response);
                result.Message = "Successfully deleted.";
                return result;
            }
            catch (Exception ex)
            {
                return OperationResponse<int>.CreateFailure(ex.Message);
            }
        }

        public OperationResponse<Email> UpdateEmail(Email email)
        {
            try
            {
                var newEmail = new Email();
                var result = new OperationResponse<Email>();
                newEmail = email;
                _repo.Update(newEmail);
                var response = _repo.SaveChanges();
                result = OperationResponse<Email>.CreateSuccesResponse(email);
                result.Message = "Successfully updated.";

                return result;
            }
            catch (Exception ex)
            {
                return OperationResponse<Email>.CreateFailure(ex.Message);
            }
        }
    }
}
