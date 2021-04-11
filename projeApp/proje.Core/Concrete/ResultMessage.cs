using System;
using System.Collections.Generic;
using System.Text;

namespace proje.Core.Concrete
{
    public class ResultMessage<T>
    {
        public string Mesaj { get; set; }
        public T Data { get; set; }
        public bool BasariliMi { get; set; }
    }
}
