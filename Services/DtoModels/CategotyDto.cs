using DataBase.ModelConstrains;
using DataBase.Models;
using System.ComponentModel.DataAnnotations;

namespace CSharpCollective.Services.DtoModels
{
    public class CategoryDto
    {
        public CategoryDto(string Name)
        {

            this.Name = Name;
            this.Posts = new HashSet<Post>();
        }
        [Key]
        public int Id { get; set; }
        [MaxLength(Constrains.MaxCategoryNameLength)]
        public string Name { get; set; }

        public virtual ICollection<Post>? Posts { get; set; }
    }
}