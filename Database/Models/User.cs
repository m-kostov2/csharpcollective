
using System.ComponentModel.DataAnnotations;

namespace DataBase.Models
{
    public class User
    {
        public User()
        {
            
        }

        public User(string email,string password)
        {
            this.Id = Guid.NewGuid();
            this.Email = email;
            this.Password = password;
            Comments = new HashSet<Comment>();
            Posts = new HashSet<Post>();
            this.Role = "User";
            this.CreatedAt = DateTime.Now;
          

        }
        [Key]
        private Guid Id { get; set; }
        public string? UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }     
        public string Role { get;  set; }
        private  DateTime CreatedAt { get; set; }
        public DateTime LastOnline { get; set; }

        public virtual ICollection<Comment>? Comments { get; set; }

        public virtual ICollection<Post>? Posts { get; set; }



    }
}

//one - to - many,  ---check user to posts/comments
//one - to - one,   -- check comment to user
//many - to - many   -- check posts to tags