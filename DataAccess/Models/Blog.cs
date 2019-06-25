using System.Collections.Generic;

namespace DataAccess.Models
{

    public class Blog
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public BlogPost Post { get; set; }

        public ICollection<BlogPost> Posts { get; set; }

    }

}
