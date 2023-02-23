using MeetingApp.Business.Utils;
using MeetingApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingApp.Business.Abstracts
{
    public interface IMeetingParticipantService
    {
        OperationResponse<List<MeetingParticipant>> GetAllMeetingParticipants();
        OperationResponse<MeetingParticipant> GetMeetingParticipant(int id);
        OperationResponse<MeetingParticipant> AddMeetingParticipant(MeetingParticipant meetingParticipant);
        OperationResponse<MeetingParticipant> UpdateMeetingParticipant(MeetingParticipant meetingParticipant);
        OperationResponse<int> RemoveMeetingParticipant(int id);
    }
}
