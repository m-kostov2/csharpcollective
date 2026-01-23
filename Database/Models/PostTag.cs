using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class PostTag
    {

        public PostTag()
        {
            
        }

        public Guid PostId { get; set; }
        public virtual Post Post { get; set; } = null!;
        public Guid TagId { get; set; }
        public virtual Tag Tag { get; set; } = null!;
    }
}
