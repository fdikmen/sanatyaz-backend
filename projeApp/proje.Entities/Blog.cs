using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proje.Entities
{
    public class Blog:Base
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public DateTime DateTime { get; set; }
        public bool isActive { get; set; }
        public bool GetHomepage { get; set; }
        public int Order { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        
    }    
}
