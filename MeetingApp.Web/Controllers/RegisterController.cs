using MeetingApp.Business.Abstracts;
using MeetingApp.Entities.Models;
using MeetingApp.Utils;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using NuGet.Common;
using System.IO.Compression;

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
        public IActionResult SingUp(User user, IFormFile file)
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
                    memoryStream.CopyTo(compressedStream);
                    user.ProfilePhoto = compressedStream.ToArray();
                }
            }

            byte[] bytes = new byte[0];
            user.ProfilePhoto = user.ProfilePhoto ?? bytes;

            userService.AddUser(user);

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
            if (ModelState.IsValid)
            {

                var token = userService.Authenticate(model);

                if (!string.IsNullOrEmpty(token.Result.VerifiedToken))
                {
                    var authUser = userService.GetAllUsers().Result.Resource.FirstOrDefault(x => x.Mail == model.Mail && Encription.Decrypt(x.Password) == model.Password);

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
