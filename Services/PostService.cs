using AutoMapper;
using CSharpCollective.Services.DtoModels;
using DataBase.DataContext;
using DataBase.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Linq;


namespace Services
{
    public class PostService
    {
        private CollectiveContext _context;
        private readonly IMapper _mapper;


        public PostService(IMapper mapper)
        {
            _context = new CollectiveContext();
            _mapper = mapper;

        }



        public PostDto Create(PostDto Datarecieved)
        {


            Post postInfo = new Post(Datarecieved.Title, Datarecieved.Content);


            _mapper.Map(Datarecieved, postInfo);

            var postExists = _context.Posts.Any(p => p.Id == postInfo.Id);
            if (postExists != null)
            {
                string authorName = _context.Users.Where(u => u.Id == postInfo.AuthorId).Select(u => u.UserName).FirstOrDefault();
                _context.Posts.AddAsync(postInfo);
                _context.SaveChanges();
            }
            PostDto postDtoInfo = new PostDto(postInfo.Title, postInfo.Content, postInfo.Id);




            return postDtoInfo;

        }
        public void Edit(PostDto Datarecieved)
        {

            string title = Datarecieved.Title;
            string content = Datarecieved.Content;
            if (title == null & content == null || title.Length > 100 & content.Length > 2000 & title.Length <= 0)
            {
                Datarecieved = null;
            }


            Post postInfo = new Post();
            _mapper.Map(Datarecieved, postInfo);
            postInfo = _context.Posts.Where(p => p.Id == Datarecieved.Id).Single();
            Datarecieved.AuthorId = postInfo.AuthorId;
            Datarecieved.UpdatedAt = DateTime.Now;
            _mapper.Map(Datarecieved, postInfo);
            _context.SaveChangesAsync();

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
            var posts = _context.Posts.Select(n => new Post
            {
                Id = n.Id,
                Title = n.Title,
                Content = n.Content,
                AuthorId = n.AuthorId
            }
                ).ToList();
            var postDtos = _mapper.Map<List<Post>, List<PostDto>>(posts);
            return postDtos;
        }

        public IEnumerable<PostDto> GetAllByCategory(string category)
        {
            var posts = _context.Posts
            .Include(p => p.Categories)
            .Where(p => p.Categories.Any(c => c.Name.ToLower() == category.ToLower())).
            Select(n => new Post
            {
                Id = n.Id,
                Title = n.Title,
                Content = n.Content,
                AuthorId = n.AuthorId
            }
                )
            .ToList();
            var postDtos = _mapper.Map<List<Post>, List<PostDto>>(posts);
            return postDtos;
        }





        public PostDto GetById(Guid id)
        {

            Post post = _context.Posts.SingleOrDefault(p => p.Id == id);
            PostDto postDto = _mapper.Map<Post, PostDto>(post);

            return postDto;


        }

      
        public void AddCategoryToPost(Guid Id, string Category)
        {

            var category = _context.Categories
           .FirstOrDefault(c => c.Name.ToLower() == Category.ToLower().Trim());

            if (category == null)
            {
                category = new Category { Name = Category };
            }

            var post = _context.Posts
                .Include(p => p.Categories)
                .FirstOrDefault(p => p.Id == Id);

            if (post != null)
            {

                if (!post.Categories.Any(c => c.Name.ToLower() == Category.ToLower().Trim()))
                {
                    post.Categories.Add(category);
                }

                _context.SaveChanges();



            }
        }



        public PostDto PostCheck(PostDto Datarecieved)
        {
            PostDto postDto = new PostDto();
            postDto = Datarecieved;
            string title = Datarecieved.Title;
            string content = Datarecieved.Content;

            if (title.IsNullOrEmpty() & content.IsNullOrEmpty() || title.Length > 100 & content.Length > 2000 & title.Length <= 0)
            {
                return null;
            }

            return postDto;

        }
    }
}
