using proje.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proje.UI.Models
{
    public class MailViewModel
    {
        public IEnumerable<Mail> Mails { get; set; }
        public Mail Mail { get; set; }
        public IEnumerable<User> Users { get; set; }
        public User User { get; set; }
        

    }
}
