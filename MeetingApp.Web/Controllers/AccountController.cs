using Microsoft.AspNetCore.Mvc;

namespace MeetingApp.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}
