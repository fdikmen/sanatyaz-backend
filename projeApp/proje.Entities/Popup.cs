using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace proje.Entities
{
    public class Popup:Base
    {
        [Required]
        [StringLength(45)]
        public string Title { get; set; }        
        [StringLength(100)]
        public string Text { get; set; }
        public string popupUrl { get; set; }
        public bool isActive { get; set; }
        public string imageUrl { get; set; }
    }
}
