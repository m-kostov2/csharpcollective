using AutoMapper;
using CSharpCollective.Services.DtoModels;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace CSharpCollective.Controllers
{
    public class CategoryController : Controller
    {
       
        private PostService _postService;

        public CategoryController(IMapper mapper)
        {
            _postService = new PostService(mapper);
        }
        [HttpGet]
        public IActionResult Category(string category)
        {
            if (string.IsNullOrWhiteSpace(category))
            {
                return View(new List<PostDto>());
            }

            var posts = _postService.GetAllByCategory(category);

            return View(posts);
        }
 
    }
}
