using DataBase.ModelConstrains;
using DataBase.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSharpCollective.Services.DtoModels
{
    public class CommentDto
    {
        public CommentDto()
        {
            
        }

        public CommentDto(string content)
        {
            this.Content = content;
        }
        public Guid Id { get; set; }

        [ForeignKey(nameof(Author))]
        public Guid AuthorId { get; set; }
        public string AuthorName { get; private set; }     
        public virtual UserDto Author { get; set; }
        [MaxLength(Constrains.MaxCommentContentLength)]
        public string Content { get; private set; }
    }
}