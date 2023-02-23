using MeetingApp.Business.Utils;
using MeetingApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingApp.Business.Abstracts
{
    public interface IMeetingService
    {
        OperationResponse<List<Meeting>> GetAllMeetings();
        OperationResponse<Meeting> GetMeeting(int id);
        OperationResponse<Meeting> AddMeeting(Meeting meeting);
        OperationResponse<Meeting> UpdateMeeting(Meeting meeting);
        OperationResponse<int> RemoveMeeting(int id);
    }
}
