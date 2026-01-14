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
        public Comment(string content)
        {
            this.Id = Guid.NewGuid();
            this.Content = content;
            this.CreatedAt = DateTime.UtcNow;
        }
        [Key]
        private Guid Id { get; set; }
        public int AuthorId { get; private set; }
        public virtual User Author { get; set; }
        public string Content { get; private set; }
        public DateTime CreatedAt { get; private set; }


    }
}
