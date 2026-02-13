using AutoMapper;
using CSharpCollective.Services.DtoModels;
using DataBase.DataContext;
using DataBase.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.EntityFrameworkCore;
using Services;
using System;

namespace CSharpCollective.Controllers
{
    public class PostController : Controller
    {
        private PostService postService;

        public PostController(CollectiveContext context, IMapper mapper)
        {


            postService = new PostService(context, mapper);

        }



        public IActionResult Post()
        {
            var posts = postService.GetAll();

            if (!posts.Any())
                return RedirectToAction("Create"); 

            return View(posts); 
        }

       
        public IActionResult Create()
        {
            return View("CreatePost"); 
        }

        
        public IActionResult Create(PostDto post)
        {
            string userIdString = HttpContext.Session.GetString("UserId");
            if (string.IsNullOrEmpty(userIdString))
                return Unauthorized();

            post.AuthorId = Guid.Parse(userIdString);
            postService.Create(post);

            return RedirectToAction("Post"); 
        }

        public IActionResult Edit(PostDto post)
        {
       postService.Edit(post);


            return View("Edit", post); 
        }

    
        public IActionResult Delete(Guid id)
        {
             postService.Delete(id);
          

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
