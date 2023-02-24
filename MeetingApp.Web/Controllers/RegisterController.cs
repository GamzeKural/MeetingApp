using MeetingApp.Business.Abstracts;
using MeetingApp.Entities.Models;
using MeetingApp.Utils;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;

namespace MeetingApp.Web.Controllers
{
    public class RegisterController : Controller
    {
        private readonly Business.Services.Abstracts.IUserService userService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RegisterController(Business.Services.Abstracts.IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            this.userService = userService;
            _httpContextAccessor = httpContextAccessor;
        }


        
        [HttpGet]
        public IActionResult SingUp()
        {
            User userModel = new User();
            return View(userModel);
        }

        [HttpPost]
        public IActionResult SingUp(User user)
        {
            if(ModelState.IsValid)
            {
                userService.AddUser(user);
            }

            return RedirectToAction("Index", "Account");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(AuthModel model)
        {
            if(ModelState.IsValid)
            {
                var token = userService.Authenticate(model);

                if (!string.IsNullOrEmpty(token.Result.VerifiedToken))
                {
                    var authUser = userService.GetAllUsers().Result.Resource.FirstOrDefault(x => x.Mail == model.Mail  && Encription.Decrypt(x.Password) == model.Password);

                    _httpContextAccessor.HttpContext.Session.SetString("UserName", authUser.Mail);
                    _httpContextAccessor.HttpContext.Session.SetString("Token", token.Result.VerifiedToken);
                    _httpContextAccessor.HttpContext.Session.SetInt32("UserId", authUser.Id);

                    return RedirectToAction("Index", "Meeting", null);
                }
                else
                    return RedirectToAction("Login");
            }

            return RedirectToAction("Login");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Login");
        }
    }

    
}
