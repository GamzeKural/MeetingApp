using MeetingApp.Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace MeetingApp.Web.Controllers
{
    public class MeetingController : Controller
    {
        private readonly Business.Services.Abstracts.IMeetingService meetingService;
        private readonly Business.Services.Abstracts.IUserService userService;

        public MeetingController(Business.Services.Abstracts.IMeetingService meetingService, Business.Services.Abstracts.IUserService userService)
        {
            this.meetingService = meetingService;
            this.userService = userService;
        }



        [HttpGet]
        public IActionResult Index()
        {
            var meetings = meetingService.GetAllMeetings().Result.Resource;

            return View(meetings);
        }

        [HttpPost]
        public IActionResult Create(Meeting meeting)
        {
            var users = userService.GetAllUsers().Result.Resource;
            ViewBag.User = new SelectList(users, "Id", "Mail");

            if (ModelState.IsValid)
            {
                meetingService.AddMeeting(meeting);
            }

            return RedirectToAction("Index", "Meeting");
        }
    }
}
