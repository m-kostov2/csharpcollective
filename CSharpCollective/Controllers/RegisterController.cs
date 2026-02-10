using AutoMapper;
using CSharpCollective.Services.DtoModels;
using DataBase.DataContext;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        public IActionResult Register(UserDto user)
        {
            user = registerService.registerUser(user);
            if (user != null)
            {
                HttpContext.Session.SetString("UserId", user.Id.ToString());
                return RedirectToAction("MainPage", "MainPage");
            }

            TempData["RegisterError"] = "Register Error";
            return View();
        }
    }
}
