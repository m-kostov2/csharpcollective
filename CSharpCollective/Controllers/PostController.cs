using AutoMapper;
using CSharpCollective.Services;
using CSharpCollective.Services.DtoModels;
using DataBase.DataContext;
using DataBase.Models;
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



        public PostController(CollectiveContext context, IMapper mapper)
        {


            _postService = new PostService(context, mapper);


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

            var postCheck = _postService.PostCheck(post);
            if (postCheck == null)
            {
                TempData["ErrorMessage"] = "Title or content exceeds maximum length of 100 and 2000 or one of them is empty. Please try again.";
                return RedirectToAction("Create");
            }
            _postService.Create(post);

            return RedirectToAction("Post");
        }
        //Ninject ,Casstle Windsor


        [HttpGet]
        public IActionResult Edit(Guid id)
        {

            var post = _postService.GetById(id);
            if (post == null)
            {
                return NotFound();

            }
            return View("Edit",post);
        }

        public IActionResult Edit(PostDto post)
        {

            

            var postCheck = _postService.PostCheck(post);
            if (postCheck == null)
            {
                TempData["EditError"] = "Title or content exceeds maximum length of 100 and 2000 or one of them is empty. Please try again.";
                return RedirectToAction("Edit");
            }
              _postService.Edit(post);
            return RedirectToAction("Post");
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
