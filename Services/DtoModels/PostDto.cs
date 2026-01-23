using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSharpCollective.Services.DtoModels;
    public class PostDto
    {

        public PostDto()
        {
            
        }

        public PostDto(string title, string content)
        {

            Title = title;
            Content = content;
        }

        public string AuthorName { get; private set; }
        public string Title { get; private set; }
        public string Content { get; private set; }

    }
