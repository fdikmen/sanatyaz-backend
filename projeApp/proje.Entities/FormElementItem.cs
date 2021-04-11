using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace proje.Entities
{
    public class FormElementItem:Base
    {    
        [Required]
        public string Text { get; set; }

        [ForeignKey("FormElement")]
        public int FormElementId { get; set; }
       
        public virtual FormElement FormElement { get; set; }

    }
}
