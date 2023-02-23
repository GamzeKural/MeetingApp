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
    public class EmailRecipientController : ControllerBase
    {
        private IEmailRecipientService emailRecipientService;

        public EmailRecipientController(IEmailRecipientService emailRecipientService)
        {
            this.emailRecipientService = emailRecipientService;
        }

        [HttpGet("GetAllEmailRecipients")]
        public ActionResult<OperationResponse<List<EmailRecipient>>> GetAllEmailRecipients()
        {
            try
            {
                var result = emailRecipientService.GetAllEmailRecipients();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem("An error occurred while fetching data:" + ex.Message);
            }
        }

        [HttpGet("GetEmailRecipient")]
        public ActionResult<OperationResponse<EmailRecipient>> GetEmailRecipient(int id)
        {
            try
            {
                var result = emailRecipientService.GetEmailRecipient(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem("An error occurred while fetching data:" + ex.Message);
            }
        }

        [HttpPost("AddEmailRecipient")]
        public ActionResult<OperationResponse<EmailRecipient>> AddEmailRecipient(EmailRecipient emailRecipient)
        {
            try
            {
                var result = emailRecipientService.AddEmailRecipient(emailRecipient);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem("An error occurred while fetching data:" + ex.Message);
            }
        }

        [HttpPut("UpdateEmailRecipient")]
        public ActionResult<OperationResponse<EmailRecipient>> UpdateEmailRecipient(EmailRecipient emailRecipient)
        {
            try
            {
                var result = emailRecipientService.UpdateEmailRecipient(emailRecipient);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem("An error occurred while fetching data:" + ex.Message);
            }
        }

        [HttpDelete("RemoveEmailRecipient")]
        public ActionResult<OperationResponse<EmailRecipient>> RemoveEmailRecipient(int id)
        {
            try
            {
                var result = emailRecipientService.RemoveEmailRecipient(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem("An error occurred while fetching data:" + ex.Message);
            }
        }
    }
}
