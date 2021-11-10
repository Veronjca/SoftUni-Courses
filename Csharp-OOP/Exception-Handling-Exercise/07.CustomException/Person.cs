using System;
using System.Collections.Generic;
using System.Text;

namespace _06.ValidPerson
{
    public class Person
    {
        private int age;
        private string firstName;
        private string lastName;
        public Person(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public int Age 
        { 
            get => this.age; 
            private set
            {
                if (value <= 0 || value > 120)
                {
                    throw new ArgumentOutOfRangeException("Invalid age!Age should be between 1-120!", new ArgumentOutOfRangeException());
                }
                this.age = value;
            }
                }
        public string FirstName
        {
            get => this.firstName;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("First name cannot be empty!", new ArgumentNullException());
                }
                this.firstName = value;
            }
        }
        public string LastName 
        { 
            get => this.lastName; 
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Last name cannot be empty!", new ArgumentNullException());
                }
                this.lastName = value;
            }
        }

    }
}
