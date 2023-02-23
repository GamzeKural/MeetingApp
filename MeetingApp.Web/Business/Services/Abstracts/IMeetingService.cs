using MeetingApp.Business.Utils;
using MeetingApp.Entities.Models;

namespace MeetingApp.Web.Business.Services.Abstracts
{
    public interface IMeetingService
    {
        Task<OperationResponse<List<Meeting>>> GetAllMeetings();
        Task<OperationResponse<Meeting>> GetMeeting(int id);
        Task<OperationResponse<Meeting>> AddMeeting(Meeting meeting);
        Task<OperationResponse<Meeting>> UpdateMeeting(Meeting meeting);
        Task<OperationResponse<int>> RemoveMeeting(int id);
    }
}
