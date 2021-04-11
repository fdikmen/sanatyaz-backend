using System;
using System.Collections.Generic;
using System.Text;

namespace proje.Entities
{
    public class PhotoCategory:Base
    {
        public string Name { get; set; }
        public bool isActive { get; set; }
        public int Order { get; set; }

        public virtual ICollection<PhotoGallery> PhotoGalleries { get; set; }
    }
}
