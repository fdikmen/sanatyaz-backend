using proje.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proje.UI.Models
{
    public class GalleryViewModel
    {
        public IEnumerable<PhotoGallery> PhotoGalleries { get; set; }
        public PhotoGallery PhotoGallery { get; set; } 
       
        public IEnumerable<PhotoCategory> PhotoCategories { get; set; }
        public PhotoCategory PhotoCategory { get; set; }
    }
}
