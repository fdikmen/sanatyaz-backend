using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proje.Entities
{
    public class Promotion:Base
    {
        public string promotionTitle { get; set; }
        public string imageUrl { get; set; }
        public string mediaUrl { get; set; }
        [StringLength(150)]
        public string promotionText { get; set; }
        public string promotionSubtitle { get; set; }
        [Required]
        public string promotionBoxSize { get; set; }
        public bool isActive { get; set; }
        public string promotionUrl { get; set; }
        public int Order { get; set; }
        public bool GetHomepage { get; set; }
    }
}
