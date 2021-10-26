using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Person
{
    public class Person
    {
        private string name;
        private int age;
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public int Age
        {
            get => age;
            set => age = value;
        }
        public string Name         
        {
            get => name;
            set => name = value;
        }

        public override string ToString()
        {
            return $"Name: {this.Name}, Age: {this.Age}";
        }
    }
}
