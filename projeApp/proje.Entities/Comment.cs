using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace proje.Entities
{
    public class Comment:Base
    {        
        public string UserName { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }


        [ForeignKey("Blog")]
        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }

        public virtual ICollection<Like> Likes { get; set; }
    }
}
