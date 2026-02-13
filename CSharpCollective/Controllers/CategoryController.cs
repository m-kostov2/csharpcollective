using Microsoft.AspNetCore.Mvc;

namespace CSharpCollective.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Category()
        {
            return View();
        }
    }
}
