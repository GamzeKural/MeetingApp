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
    public class MeetingParticipantService : IMeetingParticipantService
    {
        private readonly IRepository _repo;
        public MeetingParticipantService(IRepository repo)
        {
            _repo = repo;
        }
        public OperationResponse<MeetingParticipant> AddMeetingParticipant(MeetingParticipant meetingParticipant)
        {
            try
            {
                var newMeetingParticipant = new MeetingParticipant();
                var result = new OperationResponse<MeetingParticipant>();
                newMeetingParticipant = meetingParticipant;
                _repo.Add(newMeetingParticipant);
                _repo.SaveChanges();

                result = OperationResponse<MeetingParticipant>.CreateSuccesResponse(meetingParticipant);
                result.Message = "Successfully added.";

                return result;
            }
            catch (Exception ex)
            {
                return OperationResponse<MeetingParticipant>.CreateFailure(ex.Message);
            }
        }

        public OperationResponse<List<MeetingParticipant>> GetAllMeetingParticipants()
        {
            try
            {
                var meetingParticipants = _repo.GetAll<MeetingParticipant>().ToList();

                var result = OperationResponse<List<MeetingParticipant>>.CreateSuccesResponse(meetingParticipants);

                result.Message = "Successfully brought.";

                return result;
            }
            catch (Exception ex)
            {
                return OperationResponse<List<MeetingParticipant>>.CreateFailure(ex.Message);
            }
        }

        public OperationResponse<MeetingParticipant> GetMeetingParticipant(int id)
        {
            try
            {
                var meetingParticipant = _repo.Get<MeetingParticipant>(id);

                var result = OperationResponse<MeetingParticipant>.CreateSuccesResponse(meetingParticipant);

                result.Message = "Successfully brought.";

                return result;
            }
            catch (Exception ex)
            {
                return OperationResponse<MeetingParticipant>.CreateFailure(ex.Message);
            }
        }

        public OperationResponse<int> RemoveMeetingParticipant(int id)
        {
            try
            {
                var meetingParticipant = _repo.Get<MeetingParticipant>(id);
                _repo.Remove(meetingParticipant);
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

        public OperationResponse<MeetingParticipant> UpdateMeetingParticipant(MeetingParticipant meetingParticipant)
        {
            try
            {
                var newMeetingParticipant = new MeetingParticipant();
                var result = new OperationResponse<MeetingParticipant>();
                newMeetingParticipant = meetingParticipant;
                _repo.Update(newMeetingParticipant);
                var response = _repo.SaveChanges();
                result = OperationResponse<MeetingParticipant>.CreateSuccesResponse(meetingParticipant);
                result.Message = "Successfully updated.";

                return result;
            }
            catch (Exception ex)
            {
                return OperationResponse<MeetingParticipant>.CreateFailure(ex.Message);
            }
        }
    }
}
