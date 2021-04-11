using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace proje.Entities
{
    public class FormElement:Base
    {
        public string Text { get; set; }
        public string Type { get; set; }
        public int Order { get; set; }
        public bool isRequired { get; set; }
        public bool isActive { get; set; }
        public DateTime? AddedDate { get; set; }


        [ForeignKey("Form")]
        public int FormId { get; set; }
        public virtual Form Form { get; set; }

        public virtual ICollection<FormElementItem> FormElementItems { get; set; }
        public virtual ICollection<FormArchive> FormArchives { get; set; }

        
    }
}
