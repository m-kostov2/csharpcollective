using AutoMapper;
using CSharpCollective.Services.DtoModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Services;

namespace CSharpCollective.Controllers
{
    public class CommentController : Controller
    {

        private CommentService _commentService;



        public CommentController(IMapper mapper)
        {


            _commentService = new CommentService(mapper);


        }


        [HttpGet]
        public IActionResult Comment()
        {
            var comments = _commentService.GetAll();

            if (comments.Count().Equals(0))
            {return RedirectToAction("Create"); }
                

            return View(comments);
        }

        [OutputCache(Duration = 10)]
        [HttpGet]
        public IActionResult Create()
        {
            return View("CreateComment");
        }
        [OutputCache(Duration = 10)]
        [HttpPost]
        public IActionResult Create(CommentDto comment)
        {
            string userIdString = HttpContext.Session.GetString("UserId");
            ;
            comment.AuthorId = Guid.Parse(userIdString);

            var commentCheck = _commentService.CommentCheck(comment);
            if (commentCheck == null)
            {
                TempData["ErrorMessage"] = "Title or content exceeds maximum length of 100 and 2000 or one of them is empty. Please try again.";
                return RedirectToAction("Create");
            }
            _commentService.Create(comment);

            return RedirectToAction("Comment");
        }
        //Ninject ,Casstle Windsor

        public IActionResult Delete(Guid id)
        {
            _commentService.Delete(id);


            return RedirectToAction("Comment"); // Back to list
        }
    }
}
