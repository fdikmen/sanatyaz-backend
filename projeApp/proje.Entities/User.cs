using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace proje.Entities
{
    public class User:Base
    {        
        public string Name { get; set; }        
        public string Surname { get; set; }      
        public string Password { get; set; }    
        public string EMail { get; set; }
       
    }
}
