using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person first = new Person();
            first.Name = "Peter";
            first.Age = 20;

            Person second = new Person 
            { 
                Name = "George",
                Age = 18
            };

            Person third = new Person
            {
                Name = "Jose",
                Age = 43
            };
        }
    }
}
