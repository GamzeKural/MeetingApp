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
    public class EmailController : ControllerBase
    {
        private IEmailService emailService;

        public EmailController(IEmailService emailService)
        {
            this.emailService = emailService;
        }

        [HttpGet("GetAllEmails")]
        public ActionResult<OperationResponse<List<Email>>> GetAllEmails()
        {
            try
            {
                var result = emailService.GetAllEmails();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem("An error occurred while fetching data:" + ex.Message);
            }
        }

        [HttpGet("GetEmail")]
        public ActionResult<OperationResponse<Email>> GetEmail(int id)
        {
            try
            {
                var result = emailService.GetEmail(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem("An error occurred while fetching data:" + ex.Message);
            }
        }

        [HttpPost("AddEmail")]
        public ActionResult<OperationResponse<Email>> AddEmail(Email email)
        {
            try
            {
                var result = emailService.AddEmail(email);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem("An error occurred while fetching data:" + ex.Message);
            }
        }

        [HttpPut("UpdateEmail")]
        public ActionResult<OperationResponse<Email>> UpdateEmail(Email email)
        {
            try
            {
                var result = emailService.UpdateEmail(email);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem("An error occurred while fetching data:" + ex.Message);
            }
        }

        [HttpDelete("RemoveEmail")]
        public ActionResult<OperationResponse<Email>> RemoveEmail(int id)
        {
            try
            {
                var result = emailService.RemoveEmail(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem("An error occurred while fetching data:" + ex.Message);
            }
        }
    }
}
