using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace proje.Entities
{
    public class PhotoGallery:Base
    {
        public string imageUrl { get; set; }
        public bool isActive { get; set; }

        [ForeignKey("PhotoCategory")]
        public int PhotoCategoryId { get; set; }
        public virtual PhotoCategory PhotoCategory { get; set; }
    }
}
