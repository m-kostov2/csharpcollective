using System.ComponentModel.DataAnnotations;

namespace CSharpCollective.Models.DtoModels
{
    public class TagDto
    {

        public TagDto(string name)
        {
            this.Name = name;

        }
        public string Name { get; private set; }
    }
}