using DataBase.ModelConstrains;
using System.ComponentModel.DataAnnotations;

namespace CSharpCollective.Services.DtoModels
{
    public class UserDto
    {
        public UserDto()
        {
            
        }
        public UserDto(string email, string password)
        {

            this.Email = email;
            this.Password = password;
            Posts = new HashSet<PostDto>();

        }
        [MinLength(5), MaxLength(Constrains.MaxUserNameLength)]
        public string? UserName { get; set; }
        [MinLength(5), MaxLength(Constrains.MaxPasswordLength)]
        public string Password { get; set; }
        [MaxLength(Constrains.MaxEmailLength)]
        public string Email { get; set; }
        public string Role { get; set; }

        public virtual ICollection<PostDto>? Posts { get; set; }

    }
}