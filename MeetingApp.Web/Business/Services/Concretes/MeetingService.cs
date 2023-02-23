using MeetingApp.Business.Utils;
using MeetingApp.Entities.Models;
using MeetingApp.Web.Business.Services.Abstracts;

namespace MeetingApp.Web.Business.Services.Concretes
{
    public class MeetingService : IMeetingService
    {
        private readonly IHttpService httpService;

        public MeetingService(IHttpService httpService)
        {
            this.httpService = httpService;
        }
        public async Task<OperationResponse<Meeting>> AddMeeting(Meeting meeting)
        {
            try
            {
                var result = await httpService.Post<OperationResponse<Meeting>>("Meeting/AddMeeting", meeting);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<OperationResponse<List<Meeting>>> GetAllMeetings()
        {
            try
            {
                var result = await httpService.Get<OperationResponse<List<Meeting>>>("Meeting/GetAllMeetings");
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<OperationResponse<Meeting>> GetMeeting(int id)
        {
            try
            {
                var result = await httpService.Get<OperationResponse<Meeting>>($"Meeting/GetMeeting?id={id}");
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<OperationResponse<int>> RemoveMeeting(int id)
        {
            try
            {
                var result = await httpService.Delete<OperationResponse<int>>($"Meeting/RemoveMeeting?id={id}");
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<OperationResponse<Meeting>> UpdateMeeting(Meeting meeting)
        {
            try
            {
                var result = await httpService.Put<OperationResponse<Meeting>>("Meeting/UpdateMeeting", meeting);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
