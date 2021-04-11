using System;
using System.Collections.Generic;
using System.Text;

namespace proje.Entities
{
    public class Log:Base
    {
        public string RowId { get; set; }
        public string TableName { get; set; }
        public string Changed { get; set; }
        public EntityState Kind { get; set; }
        public DateTime Created { get; set; }
    }
    public enum EntityState
    {
        Detached = 0,
        Unchanged = 1,
        Deleted = 2,
        Modified = 3,
        Added = 4
    }        
}
