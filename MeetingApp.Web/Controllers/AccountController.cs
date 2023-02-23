using Microsoft.AspNetCore.Mvc;

namespace MeetingApp.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            //Dictionary<string, string> items = new Dictionary<string, string>();
            //items.Add("key:mail", "value:isim");
            //items.Add("item2", "Item 2");
            //items.Add("item3", "Item 3");

            //ViewBag.Items = items;

            return View();
        }
    }
}
