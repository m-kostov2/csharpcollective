using System.ComponentModel.DataAnnotations;

namespace CSharpCollective.Models.DtoModels
{
    public class UserDto
    {

        public UserDto(string email, string password)
        {

            this.Email = email;
            this.Password = password;


        }
        public string? UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public string Role
        {
            get 
            {
                return Role;

            }
            set
            {
                if (value == null)
                {
                    Role = "User";
                }
            }
        }

    }
}