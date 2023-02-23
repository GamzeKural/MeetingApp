using MeetingApp.Business.Utils;
using MeetingApp.Entities.Models;
using MeetingApp.Web.Business.Services.Abstracts;

namespace MeetingApp.Web.Business.Services.Concretes
{
    public class EmailService : IEmailService
    {
        private readonly IHttpService httpService;

        public EmailService(IHttpService httpService)
        {
            this.httpService = httpService;
        }
        public async Task<OperationResponse<Email>> AddEmail(Email email)
        {
            try
            {
                var result = await httpService.Post<OperationResponse<Email>>("Email/AddEmail", email);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<OperationResponse<List<Email>>> GetAllEmails()
        {
            try
            {
                var result = await httpService.Get<OperationResponse<List<Email>>>("Email/GetAllEmails");
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<OperationResponse<Email>> GetEmail(int id)
        {
            try
            {
                var result = await httpService.Get<OperationResponse<Email>>($"Email/GetEmail?id={id}");
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<OperationResponse<int>> RemoveEmail(int id)
        {
            try
            {
                var result = await httpService.Delete<OperationResponse<int>>($"Email/RemoveEmail?id={id}");
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<OperationResponse<Email>> UpdateEmail(Email email)
        {
            try
            {
                var result = await httpService.Put<OperationResponse<Email>>("Email/UpdateEmail", email);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
