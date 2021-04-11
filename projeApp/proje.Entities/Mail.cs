using System;
using System.Collections.Generic;
using System.Text;

namespace proje.Entities
{
    public class Mail:Base
    {
        public string Subject { get; set; }
        public string Message { get; set; }
        public string Email { get; set; }
        //public string File { get; set; }
        public DateTime AddDateTime { get; set; }
        public bool Ebulten { get; set; }
        public bool Contact { get; set; }
    }
}
