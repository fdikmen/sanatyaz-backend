using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proje.Entities
{
    public class Category:Base
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string iconClass { get; set; }
        public bool isActive { get; set; }
        public int Order { get; set; }


    }
}
