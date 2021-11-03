using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public class Citizen : IPerson
    {
        public Citizen(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public int Age { get; set; }
        public string Name { get; set; }
    }
}
