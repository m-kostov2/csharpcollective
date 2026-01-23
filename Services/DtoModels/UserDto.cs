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
        public string? UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public virtual ICollection<PostDto>? Posts { get; set; }

    }
}