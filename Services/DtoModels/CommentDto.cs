using DataBase.ModelConstrains;
using System.ComponentModel.DataAnnotations;

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
        public string AuthorName { get; private set; }
        public virtual UserDto Author { get; set; }
        [MaxLength(Constrains.MaxCommentContentLength)]
        public string Content { get; private set; }
    }
}