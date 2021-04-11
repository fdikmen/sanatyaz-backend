using System;
using System.Collections.Generic;
using System.Text;

namespace proje.Entities
{
    public class Contact: Base
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Text { get; set; }
        public string Email { get; set; }
    }
}
