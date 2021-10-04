using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Person> people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = info[0];
                int age = int.Parse(info[1]);
                people.Add(new Person(name, age));
            }

            people.Where(p => p.Age > 30).OrderBy(p => p.Name).ToList().ForEach(p => Console.WriteLine($"{p.Name} - {p.Age}"));
        }
    }
}
