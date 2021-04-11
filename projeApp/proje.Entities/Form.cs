using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace proje.Entities
{
    public class Form:Base
    {
        public string Title { get; set; }
        public string Content { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }        
        public DateTime TheEndDate { get; set; }
        public DateTime AddedDate { get; set; }
        public bool isActive { get; set; }

        public virtual ICollection<FormElement> FormElements { get; set; }
        

    }
}
