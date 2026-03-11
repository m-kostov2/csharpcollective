
using System.ComponentModel.DataAnnotations;
using DataBase.ModelConstrains; 
namespace DataBase.Models
{
    public class User
    {
        public User()
        {
            
        }

        public User(string email,string password,string username)
        {
            this.Id = Guid.NewGuid();
            this.Email = email;
            this.Password = password;
            this.UserName = username;
            Comments = new HashSet<Comment>();
            Posts = new HashSet<Post>();
            this.Role = "User";
            this.CreatedAt = DateTime.Now;
            this.LastOnline = DateTime.Now;


        }
        [Key]
        public Guid Id { get; set; }
        [MinLength(5),MaxLength(Constrains.MaxUserNameLength)]
        public string? UserName { get; set; }
        [MinLength(5), MaxLength(Constrains.MaxPasswordLength)]
        public string Password { get; set; }
        [MaxLength(Constrains.MaxEmailLength)]
        public string Email { get; set; }     
        public string Role { get; set; }
        public  DateTime CreatedAt { get; set; }
        public DateTime LastOnline { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Post>? Posts { get; set; }



    }
}

//one - to - many,  ---check user to posts/comments
//one - to - one,   -- check comment to user
//many - to - many   -- check posts to tags