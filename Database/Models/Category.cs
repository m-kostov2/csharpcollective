using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Models
{
    public class Category
    {

        public Category(string Name)
        {
               this.Posts = new HashSet<Post>();
               this.Name = Name;
        }
        [Key]
        public int Id { get;  set; }
        public string Name { get; private set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
