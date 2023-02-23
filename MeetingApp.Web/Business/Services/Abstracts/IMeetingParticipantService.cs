using MeetingApp.Business.Utils;
using MeetingApp.Entities.Models;

namespace MeetingApp.Web.Business.Services.Abstracts
{
    public interface IMeetingParticipantService
    {
        Task<OperationResponse<List<MeetingParticipant>>> GetAllMeetingParticipants();
        Task<OperationResponse<MeetingParticipant>> GetMeetingParticipant(int id);
        Task<OperationResponse<MeetingParticipant>> AddMeetingParticipant(MeetingParticipant meetingParticipant);
        Task<OperationResponse<MeetingParticipant>> UpdateMeetingParticipant(MeetingParticipant meetingParticipant);
        Task<OperationResponse<int>> RemoveMeetingParticipant(int id);
    }
}
