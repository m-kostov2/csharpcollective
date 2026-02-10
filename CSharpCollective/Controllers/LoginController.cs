using AutoMapper;
using CSharpCollective.Services.DtoModels;
using DataBase.DataContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Services;


namespace CSharpCollective.Controllers
{
    public class LoginController : Controller
    {       
        private LoginService loginService;

        public LoginController(CollectiveContext context,IMapper mapper)
        {
                
            
            loginService = new LoginService(context,mapper);

        }

        [HttpGet]
        public IActionResult Login()
        {       
            return View();
        }

        [HttpPost] 
       

        public IActionResult Login(UserDto user)
        {
            user = loginService.userExists(user);
            if (user==null)
            {  
                TempData["LoginError"] = "User not found.";
                return View();
                //return RedirectToAction("Register", "Register"); 
            }
            // Session["UserId"] = user.Id;

         
            
            HttpContext.Session.SetString("UserId", user.Id.ToString());
           
            return RedirectToAction("MainPage", "MainPage");
        }

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
