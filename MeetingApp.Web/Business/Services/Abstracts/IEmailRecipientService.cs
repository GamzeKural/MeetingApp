using MeetingApp.Business.Utils;
using MeetingApp.Entities.Models;

namespace MeetingApp.Web.Business.Services.Abstracts
{
    public interface IEmailRecipientService
    {
        Task<OperationResponse<List<EmailRecipient>>> GetAllEmailRecipients();
        Task<OperationResponse<EmailRecipient>> GetEmailRecipient(int id);
        Task<OperationResponse<EmailRecipient>> AddEmailRecipient(EmailRecipient emailRecipient);
        Task<OperationResponse<EmailRecipient>> UpdateEmailRecipient(EmailRecipient emailRecipient);
        Task<OperationResponse<int>> RemoveEmailRecipient(int id);
    }
}
