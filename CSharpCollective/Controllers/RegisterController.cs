using AutoMapper;
using CSharpCollective.Services.DtoModels;
using DataBase.DataContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Services;

namespace CSharpCollective.Controllers
{
    public class RegisterController : Controller
    {

        private RegisterService registerService;
        

        public RegisterController(CollectiveContext context, IMapper mapper)
        {


            registerService = new RegisterService(context, mapper);

        }




        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [OutputCache(Duration = 10)]
        [HttpPost]
        public IActionResult Register(UserDto user)
        {
            user = registerService.registerUser(user);
            if (user != null)
            {
                HttpContext.Session.SetString("UserId", user.Id.ToString());
                HttpContext.Session.SetString("UserRole", user.Role);
                return RedirectToAction("MainPage", "MainPage");
            }

            TempData["RegisterError"] = "User Exists";
            return View();
        }
    }
}
