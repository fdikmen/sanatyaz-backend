using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace proje.Entities
{
    public class Constant:Base
    {
        public string LogoUrl { get; set; }
        public string FooterLogoUrl { get; set; }
        public string Phone { get; set; }
        public string EMail { get; set; }
        public string IconClass { get; set; }
        public string Address { get; set; }
        public string FacebookUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string YoutubeUrl { get; set; }
        public string Whatsapp { get; set; }
        public string Text { get; set; }
        public string Shift { get; set; }
        public string Linkedin { get; set; }
    }
}
