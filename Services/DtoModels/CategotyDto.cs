using System.ComponentModel.DataAnnotations;

namespace CSharpCollective.Services.DtoModels
{
    public class CategoryDto
    {
        public CategoryDto(string Name)
        {

            this.Name = Name;
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; private set; }
    }
}