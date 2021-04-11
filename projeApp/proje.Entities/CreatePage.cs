using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace proje.Entities
{
    public class CreatePage:Base
    {
        public string Content { get; set; }
        public bool isActive { get; set; }

        //[ForeignKey("Slider")]
        //public int SliderId { get; set; }
        //public virtual Slider Slider { get; set; }

        //[ForeignKey("Promotion")]
        //public int PromotionId { get; set; }
        //public virtual Promotion Promotion { get; set; }

        [ForeignKey("Menu")]
        public int MenuId { get; set; }
        public virtual Menu Menu { get; set; }
        
        //[ForeignKey("Blog")]
        //public int BlogId { get; set; }
        //public virtual Blog Blog { get; set; }

        //[ForeignKey("Category")]
        //public int CategoryId { get; set; }
        //public virtual Category Category { get; set; }
    }
}
