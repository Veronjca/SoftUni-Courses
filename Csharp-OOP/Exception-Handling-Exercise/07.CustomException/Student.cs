using System;
using System.Collections.Generic;
using System.Text;

namespace _06.ValidPerson
{
    public class Student
    {
        private string name;

        public Student(string name, string email)
        {
            this.Name = name;
            this.Email = email;
        }
        public string Name 
        { 
            get => this.name; 
            private set
            {
                foreach (var item in value)
                {
                    if (char.IsDigit(item) || char.IsPunctuation(item) || char.IsSymbol(item))
                    {
                        throw new InvalidPersonNameException("Name should not contain any digits, symbols or punctuation marks!");
                    }
                }
                this.name = value;

            }
        }
        public string Email { get; private set; }

    }
}
