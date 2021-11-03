using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public interface IPerson
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }
}
