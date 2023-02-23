using MeetingApp.Business.Utils;
using MeetingApp.Entities.Models;
using MeetingApp.Web.Business.Services.Abstracts;

namespace MeetingApp.Web.Business.Services.Concretes
{
    public class MeetingParticipantService : IMeetingParticipantService
    {
        private readonly IHttpService httpService;

        public MeetingParticipantService(IHttpService httpService)
        {
            this.httpService = httpService;
        }
        public async Task<OperationResponse<MeetingParticipant>> AddMeetingParticipant(MeetingParticipant meetingParticipant)
        {
            try
            {
                var result = await httpService.Post<OperationResponse<MeetingParticipant>>("MeetingParticipant/AddMeetingParticipant", meetingParticipant);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<OperationResponse<List<MeetingParticipant>>> GetAllMeetingParticipants()
        {
            try
            {
                var result = await httpService.Get<OperationResponse<List<MeetingParticipant>>>("MeetingParticipant/GetAllMeetingParticipants");
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<OperationResponse<MeetingParticipant>> GetMeetingParticipant(int id)
        {
            try
            {
                var result = await httpService.Get<OperationResponse<MeetingParticipant>>($"MeetingParticipant/GetMeetingParticipant?id={id}");
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<OperationResponse<int>> RemoveMeetingParticipant(int id)
        {
            try
            {
                var result = await httpService.Delete<OperationResponse<int>>($"MeetingParticipant/RemoveMeetingParticipant?id={id}");
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<OperationResponse<MeetingParticipant>> UpdateMeetingParticipant(MeetingParticipant meetingParticipant)
        {
            try
            {
                var result = await httpService.Put<OperationResponse<MeetingParticipant>>("MeetingParticipant/UpdateMeetingParticipant", meetingParticipant);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

}
