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
        public string Name { get; private set; }
    }
}