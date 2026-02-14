using AutoMapper;
using CSharpCollective.Services;
using CSharpCollective.Services.DtoModels;
using DataBase.DataContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.EntityFrameworkCore;
using Services;
using System;

namespace CSharpCollective.Controllers
{
    public class PostController : Controller
    {
        private PostService _postService;
        private LogCheck _logCheck;


        public PostController(CollectiveContext context, IMapper mapper, LogCheck logCheck)
        {


            _postService = new PostService(context, mapper);
            this._logCheck = logCheck;

        }


        [HttpGet]
        public IActionResult Post()
        {
            var posts = _postService.GetAll();

            if (posts.Count().Equals(0))
                return RedirectToAction("Create");

            return View(posts);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("CreatePost");
        }

        [HttpPost]
        public IActionResult Create(PostDto post)
        {
            string userIdString = HttpContext.Session.GetString("UserId");
            post.AuthorId = Guid.Parse(userIdString);

            var postVerified = _postService.Create(post);
            if (postVerified == null)
            {
                TempData["ErrorMessage"] = "Title or content exceeds maximum length of 100 and 2000 or one of them is empty. Please try again.";
                return RedirectToAction("Create");
            }

            return RedirectToAction("Post");
        }

        public IActionResult Edit(PostDto post)
        {
            _postService.Edit(post);


            return View("Edit", post);
        }


        public IActionResult Delete(Guid id)
        {
            _postService.Delete(id);


            return RedirectToAction("Post"); // Back to list
        }


















































        //[HttpGet]
        //public IActionResult Post()
        //{

        //    IEnumerable<PostDto> posts = postService.GetAll();
        //    if (posts.Count() == 0)
        //    {
        //        return RedirectToAction("Create");
        //    }
        //    return View(posts);
        //}

        //[HttpGet]
        //public IActionResult Create()
        //{

        //    return View("CreatePost");
        //}


        //[HttpPost]
        //public IActionResult Create(PostDto post)
        //{
        //    string userIdString = HttpContext.Session.GetString("UserId");

        //    post.AuthorId = Guid.Parse(userIdString);
        //    postService.Create(post);
        //    return View("Post");
        //}


        //[HttpGet]
        //public IActionResult Edit()
        //{

        //    return View("Edit");
        //}

        //[HttpPost]
        //public IActionResult Edit(PostDto post)
        //{
        //    postService.Edit(post);
        //    return View("Post");
        //}

        //[HttpPost]
        //public IActionResult Delete(Guid Id)
        //{

        //    return RedirectToAction("Post");
        //}




























    }
}
