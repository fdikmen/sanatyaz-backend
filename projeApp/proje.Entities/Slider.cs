using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace proje.Entities
{
    public class Slider:Base
    {
        [StringLength(100)]
        public string sliderText { get; set; }
        public string sliderTitle { get; set; }        
        public string sliderSubtitle { get; set; }        
        [StringLength(100)]
        public string sliderUrl { get; set; }
        [StringLength(100)]
        public string imageUrl { get; set; }
        [StringLength(100)]
        public string mediaUrl { get; set; }        
        public bool isActive { get; set; }
        public int Order { get; set; }



    }
}
