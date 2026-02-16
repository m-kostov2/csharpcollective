using AutoMapper;
using CSharpCollective.Services;
using DataBase.DataContext;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace CSharpCollective.Controllers
{
    public class MainPageController : Controller
    {
        private LogCheck _logCheck;


        public MainPageController(LogCheck logCheck)
        {
   
            this._logCheck = logCheck;

        }




        public IActionResult MainPage()
        {

            var userIdString = HttpContext.Session.GetString("UserId");
            ;
            var loggedIn = _logCheck.LoggedIn(userIdString);

            if (loggedIn == false)
            {
                HttpContext.Session.SetString("UserId", "");
                return RedirectToAction("Login", "Login");
            }

            return View();
        }
    }
}
