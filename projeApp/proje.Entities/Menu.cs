using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proje.Entities
{
    public class Menu:Base
    {
        public int? mainMenuId { get; set; }
        [StringLength(50)]
        [Required]
        public string menuName { get; set; }
        [StringLength(100)]
        public string imageUrl { get; set; }     

        [StringLength(50)]
        public string iconClass { get; set; }        
        public bool isActive { get; set; }        
        public bool GetHomepage { get; set; }
        public int Order { get; set; }
        public bool subMenu { get; set; }

        [ForeignKey("mainMenuId")]
        public virtual Menu mainMenu { get; set; }

        //[ForeignKey("CreatePage")]
        //public int CreatePageId { get; set; }
        //public virtual CreatePage CreatePage { get; set; }

        public virtual ICollection<CreatePage> CreatePages { get; set; }
        
    }
}
