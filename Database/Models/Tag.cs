
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Models
{
    public class Tag
    {

        public Tag()
        {
            
        }

        public Tag(string name)
        {
            Id = Guid.NewGuid();
            this.Name = name;
            Posts = new HashSet<Post>();
        }
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
       
        public virtual ICollection<Post>? Posts { get; set; } 

    }
}
