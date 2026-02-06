using DataBase.ModelConstrains;
using DataBase.Models;
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


    [ForeignKey("AuthorDto")]
    public Guid AuthorId { get; set; }
    public virtual User Author { get; set; }
    public string AuthorName { get; set; }

    [MinLength(5), MaxLength(Constrains.MaxPostTitleLength)]
    public string Title { get; private set; }
    [MaxLength(Constrains.MaxPostContentLength)]
    public string Content { get; private set; }

}
