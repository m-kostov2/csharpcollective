using AutoMapper;
using CSharpCollective.Services.DtoModels;
using DataBase.DataContext;
using DataBase.Models;
using Microsoft.AspNetCore.Mvc;
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
            RedirectToAction("Index", "Home");
            return View(user);
        }


        //public IActionResult Login(string username, string password)
        //{

        //    return RedirectToAction("Index", "Home");

        //}

        public IActionResult Register()
        {
            return View();
        }


    }
}
