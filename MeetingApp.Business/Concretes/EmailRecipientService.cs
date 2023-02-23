using MeetingApp.Business.Abstracts;
using MeetingApp.Business.Utils;
using MeetingApp.DataAccess.Abstracts;
using MeetingApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingApp.Business.Concretes
{
    public class EmailRecipientService : IEmailRecipientService
    {
        private readonly IRepository _repo;
        public EmailRecipientService(IRepository repo)
        {
            _repo = repo;
        }
        public OperationResponse<EmailRecipient> AddEmailRecipient(EmailRecipient emailRecipient)
        {
            try
            {
                var newEmailRecipient = new EmailRecipient();
                var result = new OperationResponse<EmailRecipient>();
                newEmailRecipient = emailRecipient;
                _repo.Add(newEmailRecipient);
                _repo.SaveChanges();

                result = OperationResponse<EmailRecipient>.CreateSuccesResponse(emailRecipient);
                result.Message = "Successfully added.";

                return result;
            }
            catch (Exception ex)
            {
                return OperationResponse<EmailRecipient>.CreateFailure(ex.Message);
            }
        }

        public OperationResponse<List<EmailRecipient>> GetAllEmailRecipients()
        {
            try
            {
                var emailRecipients = _repo.GetAll<EmailRecipient>().ToList();

                var result = OperationResponse<List<EmailRecipient>>.CreateSuccesResponse(emailRecipients);

                result.Message = "Successfully brought.";

                return result;
            }
            catch (Exception ex)
            {
                return OperationResponse<List<EmailRecipient>>.CreateFailure(ex.Message);
            }
        }

        public OperationResponse<EmailRecipient> GetEmailRecipient(int id)
        {
            try
            {
                var emailRecipient = _repo.Get<EmailRecipient>(id);

                var result = OperationResponse<EmailRecipient>.CreateSuccesResponse(emailRecipient);

                result.Message = "Successfully brought.";

                return result;
            }
            catch (Exception ex)
            {
                return OperationResponse<EmailRecipient>.CreateFailure(ex.Message);
            }
        }

        public OperationResponse<int> RemoveEmailRecipient(int id)
        {
            try
            {
                var emailRecipient = _repo.Get<EmailRecipient>(id);
                _repo.Remove(emailRecipient);
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

        public OperationResponse<EmailRecipient> UpdateEmailRecipient(EmailRecipient emailRecipient)
        {
            try
            {
                var newEmailRecipient = new EmailRecipient();
                var result = new OperationResponse<EmailRecipient>();
                newEmailRecipient = emailRecipient;
                _repo.Update(newEmailRecipient);
                var response = _repo.SaveChanges();
                result = OperationResponse<EmailRecipient>.CreateSuccesResponse(emailRecipient);
                result.Message = "Successfully updated.";

                return result;
            }
            catch (Exception ex)
            {
                return OperationResponse<EmailRecipient>.CreateFailure(ex.Message);
            }
        }
    }
}
