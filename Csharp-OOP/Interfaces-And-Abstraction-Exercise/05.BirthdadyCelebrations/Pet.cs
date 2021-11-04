using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection.Metadata;

namespace PersonInfo
{
    public class Pet : IBirthable
    {
        public Pet(string name, string birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }
        public string Name { get; private set; }
        public string Birthdate { get; set; }
    }
}
