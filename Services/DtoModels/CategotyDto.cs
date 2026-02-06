using System.ComponentModel.DataAnnotations;
using DataBase.ModelConstrains;

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
        [MaxLength(Constrains.MaxCategoryNameLength)]
        public string Name { get; private set; }
    }
}