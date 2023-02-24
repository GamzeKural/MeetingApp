using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeetingApp.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public string token = string.Empty;

        public AccountController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            
        }
        public IActionResult Index()
        {
            token = _httpContextAccessor.HttpContext.Session.GetString("Token");

            if (!string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Index", "Meeting");
            }
            return View();
        }
    }
}
