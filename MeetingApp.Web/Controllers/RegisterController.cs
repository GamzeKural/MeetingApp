using MeetingApp.Business.Abstracts;
using MeetingApp.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeetingApp.Web.Controllers
{
    public class RegisterController : Controller
    {
        private readonly Business.Services.Abstracts.IUserService userService;
        public RegisterController(Business.Services.Abstracts.IUserService userService)
        {
            this.userService = userService;
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

            return RedirectToAction("Index", "Home");
        }


    }
}
