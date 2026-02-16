using AutoMapper;
using CSharpCollective.Services.DtoModels;
using DataBase.DataContext;
using DataBase.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PostService
    {
        private CollectiveContext _context;
        private readonly IMapper _mapper;


        public PostService(CollectiveContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }



        public PostDto Create(PostDto Datarecieved)
        {


            Post postInfo = new Post();
            string title = Datarecieved.Title;
            string content = Datarecieved.Content;

            if (title == null & content == null || title.Length > 100 & content.Length > 2000 & title.Length <= 0)
            {
                return null; 
            }

            _mapper.Map(Datarecieved, postInfo);

            var postExists = _context.Posts.Any(p => p.Id == postInfo.Id);
            if (postExists != null)
            {
                string authorName = _context.Users.Where(u => u.Id == postInfo.AuthorId).Select(u => u.UserName).FirstOrDefault();
                _context.Posts.Add(postInfo);
                _context.SaveChanges();
            }

           
            PostDto postDtoInfo = new PostDto();
           

            return postDtoInfo;

        }
        public void Edit(PostDto Datarecieved)
        {


            Post postInfo = new Post();
            postInfo = _context.Posts.SingleOrDefault(p => p.Id == Datarecieved.Id);
            
            _mapper.Map(Datarecieved, postInfo);
            _context.SaveChanges();

        }
        public void Delete(Guid Id)
        {
            Post postInfo = new Post();
             postInfo = _context.Posts.SingleOrDefault(p => p.Id == Id);
            
             _context.Posts.Remove(postInfo);
            _context.SaveChanges();
        }

        public IEnumerable<PostDto> GetAll()
        {
            var posts = _context.Posts.ToList();
            var postDtos = _mapper.Map<List<Post>,List<PostDto>>(posts);
            return postDtos;
        }


    }
}
