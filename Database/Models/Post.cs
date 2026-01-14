using Database.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Models
{
    public class Post
    {
        public Post(string title,string content)
        {
            this.Id = Guid.NewGuid();       
            this.Title = title;
            this.Content = content;
            this.CreatedAt = DateTime.UtcNow;
            Tags = new HashSet<Tag>();
        }
        [Key]
        private Guid Id { get; set; }

        [ForeignKey("Author")]
        public int AuthorId { get; private set; }
        public User Author { get; set; }
        public string Title { get; private set; }
        public string Content { get; private set; }

        public readonly DateTime CreatedAt;
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<Tag>? Tags { get; set; }

    }
}
