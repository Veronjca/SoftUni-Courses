using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.OrderByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            List<People> allPeople = new List<People>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                allPeople.Add(new People(inputArgs[0], inputArgs[1], int.Parse(inputArgs[2])));

                input = Console.ReadLine();
            }

            allPeople = allPeople.OrderBy(x => x.Age).ToList();

            foreach (var person in allPeople)
            {
                Console.WriteLine($"{person.Name} with ID: {person.ID} is {person.Age} years old.");
            }
        }

        class People
        {
            public People (string name, string id, int age)
            {
                Name = name;
                ID = id;
                Age = age;
            }
            public string Name { get; set; }
            public string ID { get; set; }
            public int Age { get; set; }
        }
    }
}
