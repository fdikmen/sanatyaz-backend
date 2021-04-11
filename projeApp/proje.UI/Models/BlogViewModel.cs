using proje.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proje.UI.Models
{
    public class BlogViewModel
    {
        public IEnumerable<Blog> Blogs { get; set; }
        public Blog Blog { get; set; }
        //public IEnumerable<Comment> Comments { get; set; }
        //public Comment Comment { get; set; }
    }
}
