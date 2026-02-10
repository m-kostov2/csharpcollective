using Microsoft.AspNetCore.Mvc;

namespace CSharpCollective.Controllers
{
    public class MainPageController : Controller
    {
        public IActionResult MainPage()
        {

            string userIdString = HttpContext.Session.GetString("UserId");
            ;

            return View();
        }
    }
}
