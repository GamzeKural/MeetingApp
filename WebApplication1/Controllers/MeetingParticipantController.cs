using MeetingApp.Business.Abstracts;
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
    public class MeetingParticipantController : ControllerBase
    {
        private IMeetingParticipantService meetingParticipantService;

        public MeetingParticipantController(IMeetingParticipantService meetingParticipantService)
        {
            this.meetingParticipantService = meetingParticipantService;
        }

        [HttpGet("GetAllMeetingParticipants")]
        public ActionResult<OperationResponse<List<MeetingParticipant>>> GetAllMeetingParticipants()
        {
            try
            {
                var result = meetingParticipantService.GetAllMeetingParticipants();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem("An error occurred while fetching data:" + ex.Message);
            }
        }

        [HttpGet("GetMeetingParticipant")]
        public ActionResult<OperationResponse<MeetingParticipant>> GetMeetingParticipant(int id)
        {
            try
            {
                var result = meetingParticipantService.GetMeetingParticipant(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem("An error occurred while fetching data:" + ex.Message);
            }
        }

        [HttpPost("AddMeetingParticipant")]
        public ActionResult<OperationResponse<MeetingParticipant>> AddMeetingParticipant(MeetingParticipant meetingParticipant)
        {
            try
            {
                var result = meetingParticipantService.AddMeetingParticipant(meetingParticipant);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem("An error occurred while fetching data:" + ex.Message);
            }
        }

        [HttpPut("UpdateMeetingParticipant")]
        public ActionResult<OperationResponse<MeetingParticipant>> UpdateMeetingParticipant(MeetingParticipant meetingParticipant)
        {
            try
            {
                var result = meetingParticipantService.UpdateMeetingParticipant(meetingParticipant);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem("An error occurred while fetching data:" + ex.Message);
            }
        }

        [HttpDelete("RemoveMeetingParticipant")]
        public ActionResult<OperationResponse<MeetingParticipant>> RemoveMeetingParticipant(int id)
        {
            try
            {
                var result = meetingParticipantService.RemoveMeetingParticipant(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem("An error occurred while fetching data:" + ex.Message);
            }
        }
    }
}
