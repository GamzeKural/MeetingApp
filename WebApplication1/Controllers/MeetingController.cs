using MeetingApp.Business.Abstracts;
using MeetingApp.Business.Concretes;
using MeetingApp.Business.Utils;
using MeetingApp.Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeetingApp.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingController : ControllerBase
    {
        private IMeetingService meetingService;

        public MeetingController(IMeetingService meetingService)
        {
            this.meetingService = meetingService;
        }

        [HttpGet("GetAllMeetings")]
        public ActionResult<OperationResponse<List<Meeting>>> GetAllMeetings()
        {
            try
            {
                var result = meetingService.GetAllMeetings();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem("An error occurred while fetching data:" + ex.Message);
            }
        }

        [HttpGet("GetMeeting")]
        public ActionResult<OperationResponse<Meeting>> GetMeeting(int id)
        {
            try
            {
                var result = meetingService.GetMeeting(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem("An error occurred while fetching data:" + ex.Message);
            }
        }

        [HttpPost("AddMeeting")]
        public ActionResult<OperationResponse<Meeting>> AddMeeting(Meeting meeting)
        {
            try
            {
                var result = meetingService.AddMeeting(meeting);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem("An error occurred while fetching data:" + ex.Message);
            }
        }

        [HttpPut("UpdateMeeting")]
        public ActionResult<OperationResponse<Meeting>> UpdateMeeting(Meeting meeting)
        {
            try
            {
                var result = meetingService.UpdateMeeting(meeting);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem("An error occurred while fetching data:" + ex.Message);
            }
        }

        [HttpDelete("RemoveMeeting")]
        public ActionResult<OperationResponse<Meeting>> RemoveMeeting(int id)
        {
            try
            {
                var result = meetingService.RemoveMeeting(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem("An error occurred while fetching data:" + ex.Message);
            }
        }
    }
}
