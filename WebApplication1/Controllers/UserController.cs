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
    public class UserController : ControllerBase
    {
        private IUserService userService;
        private ITokenService tokenService;

        public UserController(IUserService userService, ITokenService tokenService)
        {
            this.userService = userService;
            this.tokenService = tokenService;
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("Authenticate")]
        public IActionResult Authenticate(AuthModel model)
        {
            var token = tokenService.Authenticate(model);

            if (token == null)
            {
                return Unauthorized("Invalid e-mail or password.");
            }

            return Ok(token);
        }

        [AllowAnonymous]
        [HttpGet("GetAllUsers")]
        public ActionResult<OperationResponse<List<User>>> GetAllUsers()
        {
            try
            {
                var result = userService.GetAllUsers();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem("An error occurred while fetching data:" + ex.Message);
            }
        }

        [HttpGet("GetUser")]
        public ActionResult<OperationResponse<User>> GetUser(int id)
        {
            try
            {
                var result = userService.GetUser(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem("An error occurred while fetching data:" + ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("AddUser")]
        public ActionResult<OperationResponse<User>> AddUser(User user)
        {
            try
            {
                var result = userService.AddUser(user);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem("An error occurred while fetching data:" + ex.Message);
            }
        }

        [HttpPut("UpdateUser")]
        public ActionResult<OperationResponse<User>> UpdateUser(User user)
        {
            try
            {
                var result = userService.UpdateUser(user);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem("An error occurred while fetching data:" + ex.Message);
            }
        }

        [HttpDelete("RemoveUser")]
        public ActionResult<OperationResponse<User>> RemoveUser(int id)
        {
            try
            {
                var result = userService.RemoveUser(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem("An error occurred while fetching data:" + ex.Message);
            }
        }
    }
}
