using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Models
{
    public class Comment
    {
        public Comment()
        {
            
        }

        public Comment(string content)
        {
            this.Id = Guid.NewGuid();
            this.Content = content;
            this.CreatedAt = DateTime.UtcNow;
        }
        [Key]
        public Guid Id { get;  set; }
        public Guid AuthorId { get;  set; }
        public virtual User Author { get; set; } = null!;
        public string Content { get;  set; }
        public DateTime CreatedAt { get;  set; }


    }
}
