using AutoMapper;
using CSharpCollective.Services.DtoModels;
using DataBase.DataContext;
using DataBase.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CommentService
    {


        private CollectiveContext _context;
        private readonly IMapper _mapper;


        public CommentService(IMapper mapper)
        {
            _context = new CollectiveContext();
            _mapper = mapper;

        }



        public CommentDto Create(CommentDto Datarecieved)
        {


            Comment commentInfo = new Comment(Datarecieved.Content);


            _mapper.Map(Datarecieved, commentInfo);

         
                string authorName = _context.Users.Where(u => u.Id == commentInfo.AuthorId).Select(u => u.UserName).FirstOrDefault();
                _context.Comments.AddAsync(commentInfo);
                _context.SaveChanges();
            
            CommentDto commentDtoInfo = new CommentDto(commentInfo.Content);
            _mapper.Map(commentInfo, commentDtoInfo);



            return commentDtoInfo;

        }

        public void Delete(Guid Id)
        {
            Comment commentInfo = new Comment();
            commentInfo = _context.Comments.SingleOrDefault(p => p.Id == Id);

            _context.Comments.Remove(commentInfo);
            _context.SaveChanges();
        }

        public IEnumerable<CommentDto> GetAll()
        {
            var comments = _context.Comments.Select(n => new Comment
            {
                Id = n.Id,
                Content = n.Content,
                AuthorId = n.AuthorId
            }
                ).ToList();
            var commentDtos = _mapper.Map<List<Comment>, List<CommentDto>>(comments);
            return commentDtos;
        }

        public CommentDto CommentCheck(CommentDto Datarecieved)
        {
            CommentDto commentDto = new CommentDto();
            commentDto = Datarecieved; 
            string content = Datarecieved.Content;

            if (content.IsNullOrEmpty() || content.Length > 2000 )
            {
                return null;
            }

            return commentDto;

        }



    }
}
