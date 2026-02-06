using DataBase.ModelConstrains;
using System.ComponentModel.DataAnnotations;

namespace CSharpCollective.Services.DtoModels
{
    public class TagDto
    {
        public TagDto()
        {
            
        }
        public TagDto(string name)
        {
            this.Name = name;

        }
        [MinLength(5), MaxLength(Constrains.MaxTagNameLength)]
        public string Name { get; private set; }
    }
}