using MeetingApp.Entities.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using NuGet.Common;
using System;
using System.Data;
using System.IO.Compression;

namespace MeetingApp.Web.Controllers
{
    public class MeetingController : Controller
    {
        private readonly Business.Services.Abstracts.IMeetingService meetingService;
        private readonly Business.Services.Abstracts.IUserService userService;
        private readonly Business.Services.Abstracts.IMeetingParticipantService meetingParticipantService;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IWebHostEnvironment webHostEnvironment;

        public string token = string.Empty;

        public MeetingController(Business.Services.Abstracts.IMeetingService meetingService, Business.Services.Abstracts.IUserService userService, Business.Services.Abstracts.IMeetingParticipantService meetingParticipantService, IHttpContextAccessor httpContextAccessor, IWebHostEnvironment webHostEnvironment)
        {
            this.meetingService = meetingService;
            this.userService = userService;
            this.meetingParticipantService = meetingParticipantService;
            this.httpContextAccessor = httpContextAccessor;

            token = httpContextAccessor.HttpContext.Session.GetString("Token");
            this.webHostEnvironment = webHostEnvironment;
        }

        
        [HttpGet]
        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Index", "Account");
            }

            int? currentUserId = httpContextAccessor.HttpContext.Session.GetInt32("UserId");

            var meetingparticipants = meetingParticipantService.GetAllMeetingParticipants().Result.Resource.Where(x => x.UserId == currentUserId ).Select(x => x.MeetingId).ToList();


            var meetings = meetingService.GetAllMeetings().Result.Resource;

            List<Meeting> userMeetings = new List<Meeting>();

            var users = userService.GetAllUsers().Result.Resource;

            foreach (var meetingId in meetingparticipants)
            {
                var meeting = meetings.FirstOrDefault(x => x.Id == meetingId || x.UserTheCreatedId == currentUserId);
                meeting.UserTheCreated = users.FirstOrDefault(x => x.Id == meeting.UserTheCreatedId);
                userMeetings.Add(meeting);
            }

            return View(userMeetings);
        }

        //[HttpPost]
        //public IActionResult Create(Meeting meeting)
        //{
        //    var users = userService.GetAllUsers().Result.Resource;
        //    ViewBag.User = new SelectList(users, "Id", "Mail");

        //    if (ModelState.IsValid)
        //    {
        //        meetingService.AddMeeting(meeting);
        //    }

        //    return RedirectToAction("Index", "Meeting");
        //}

        [HttpGet]
        public IActionResult Create()
        {
            var users = userService.GetAllUsers().Result.Resource;

            IDictionary<int, string> data = new Dictionary<int, string>();

            foreach (var user in users)
            {
                data.Add(user.Id, user.Mail);
            }

            MeetingModel meetingModel = new MeetingModel();

            meetingModel.data = data;

            meetingModel.StartDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            meetingModel.EndDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());

            return View(meetingModel);
        }

        [HttpPost]
        public IActionResult Create(MeetingModel model, int[] selectedData,IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                    {
                        var zipEntry = archive.CreateEntry(file.FileName, CompressionLevel.Optimal);

                        using (var zipStream = zipEntry.Open())
                        {
                            file.CopyTo(zipStream);
                        }
                    }
                    var compressedStream = new MemoryStream();
                    file.CopyTo(compressedStream);
                    model.Document = compressedStream.ToArray();                    
                }
            }

            Meeting meeting = new Meeting();

            int? currentUserId = httpContextAccessor.HttpContext.Session.GetInt32("UserId");

            meeting.UserTheCreatedId = currentUserId ?? 1;

            byte[] bytes = new byte[0];
 
            meeting.StartDate = model.StartDate;
            meeting.EndDate = model.EndDate;
            meeting.MeetingName = model.MeetingName;
            meeting.Description = model.Description;
            meeting.Document = model.Document ?? bytes;
            meeting.MeetingParticipants.Add(new MeetingParticipant() { MeetingId = 1, UserId = currentUserId ?? 0});

            foreach (var item in selectedData)
            {
                meeting.MeetingParticipants.Add(new MeetingParticipant() { MeetingId = 1, UserId = item });
            }

            meetingService.AddMeeting(meeting);

            return RedirectToAction("Index");
        }
    }
}
