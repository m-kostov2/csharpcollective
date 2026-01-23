
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
        public Post()
        {
            
        }
        public Post(string title,string content)
        {
            this.Id = Guid.NewGuid();       
            this.Title = title;
            this.Content = content;
            this.CreatedAt = DateTime.UtcNow;
            Tags = new HashSet<Tag>();
            Categories = new HashSet<Category>();
        }
        [Key]
        public Guid Id { get;  set; }


        [ForeignKey("Author")]
        public Guid AuthorId { get; set; }
        public virtual User Author { get; set; }

        public string Title { get;  set; }  
        public string Content { get;  set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<Category>? Categories { get; set; }
        public virtual ICollection<Tag>? Tags { get; set; }

    }
}
