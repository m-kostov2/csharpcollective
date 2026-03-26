using AutoMapper;
using CSharpCollective.Services.DtoModels;
using DataBase.DataContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.AspNetCore.Session;
using Services;


namespace CSharpCollective.Controllers
{
    public class LoginController : Controller
    {       
        private LoginService _loginService;
      


        public LoginController(IMapper mapper)
        {                  
            _loginService = new LoginService(mapper);

        }
        
        [HttpGet]
        public IActionResult Login()
        {       
            return View();
        }

        [HttpPost]

        [OutputCache(Duration = 10)]
        public IActionResult Login(UserDto user)
        {
            user = _loginService.userExists(user);
            if (user==null || user.Password == "Wrong Password")
            {   ViewBag.ShowSidebar = false;
                TempData["LoginError"] = "Wrong password or Username";
                return View();
                //return RedirectToAction("Register", "Register"); 
            }
            // Session["UserId"] = user.Id;

         
            
            HttpContext.Session.SetString("UserId", user.Id.ToString());
            HttpContext.Session.SetString("UserRole", user.Role);

            return RedirectToAction("MainPage", "MainPage");
        }
        [OutputCache(Duration = 10)]
        public IActionResult logOut()
        {
           

            HttpContext.Session.SetString("UserId", "");

            return RedirectToAction("MainPage", "MainPage");
        }

        //public IActionResult Login(string username, string password)
        //{

        //    return RedirectToAction("Index", "Home");

        //}




    }
}
