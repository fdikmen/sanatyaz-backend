using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace proje.Entities
{
    public class FormArchive:Base
    {
        [ForeignKey("FormElement")]
        public int FormElementId { get; set; }

        public virtual FormElement FormElement { get; set; }

        public string FormGuid { get; set; }
        public string Content { get; set; }
    }
}
