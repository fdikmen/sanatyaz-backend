using System;
using System.Collections.Generic;
using System.Text;

namespace proje.Entities
{
    public class Personel:Base
    {
        public string Name { get; set; }
        public string Job { get; set; }
        public string FacebookUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string MailUrl { get; set; }
        public string ImageUrl { get; set; }
        public bool isActive { get; set; }
        public int Order { get; set; }
    }
}
