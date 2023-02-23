using MeetingApp.Business.Utils;
using MeetingApp.Entities.Models;
using MeetingApp.Web.Business.Services.Abstracts;

namespace MeetingApp.Web.Business.Services.Concretes
{
    public class EmailRecipientService : IEmailRecipientService
    {
        private readonly IHttpService httpService;

        public EmailRecipientService(IHttpService httpService)
        {
            this.httpService = httpService;
        }
        public async Task<OperationResponse<EmailRecipient>> AddEmailRecipient(EmailRecipient emailRecipient)
        {
            try
            {
                var result = await httpService.Post<OperationResponse<EmailRecipient>>("EmailRecipient/AddEmailRecipient", emailRecipient);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<OperationResponse<List<EmailRecipient>>> GetAllEmailRecipients()
        {
            try
            {
                var result = await httpService.Get<OperationResponse<List<EmailRecipient>>>("EmailRecipient/GetAllEmailRecipients");
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<OperationResponse<EmailRecipient>> GetEmailRecipient(int id)
        {
            try
            {
                var result = await httpService.Get<OperationResponse<EmailRecipient>>($"EmailRecipient/GetEmailRecipient?id={id}");
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<OperationResponse<int>> RemoveEmailRecipient(int id)
        {
            try
            {
                var result = await httpService.Delete<OperationResponse<int>>($"EmailRecipient/RemoveEmailRecipient?id={id}");
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<OperationResponse<EmailRecipient>> UpdateEmailRecipient(EmailRecipient emailRecipient)
        {
            try
            {
                var result = await httpService.Put<OperationResponse<EmailRecipient>>("EmailRecipient/UpdateEmailRecipient", emailRecipient);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
