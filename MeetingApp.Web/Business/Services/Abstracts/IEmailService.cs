using MeetingApp.Business.Utils;
using MeetingApp.Entities.Models;

namespace MeetingApp.Web.Business.Services.Abstracts
{
    public interface IEmailService
    {
        Task<OperationResponse<List<Email>>> GetAllEmails();
        Task<OperationResponse<Email>> GetEmail(int id);
        Task<OperationResponse<Email>> AddEmail(Email email);
        Task<OperationResponse<Email>> UpdateEmail(Email email);
        Task<OperationResponse<int>> RemoveEmail(int id);
    }
}
