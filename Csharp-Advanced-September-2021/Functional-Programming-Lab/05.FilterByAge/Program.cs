using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FilterByAge
{
    class Program
    {
        static void Main(string[] args)
        {

            Func<(string name, int age), int,  bool> older = (person, age) => person.age >= age;
            Func<(string name, int age), int,  bool> younger = (person, age) => person.age < age;

            int n = int.Parse(Console.ReadLine());

            List<(string name, int age)> people = new List<(string name, int age)>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(new string[] { ", ", " " }, StringSplitOptions.RemoveEmptyEntries);

                people.Add((input[0], int.Parse(input[1])));
                    
            }

            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string [] format = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            switch (condition)
            {
                case "older":
                    people = people.Where(p => older(p, age)).ToList();
                    break;
                case "younger":
                    people = people.Where(p => younger(p, age)).ToList();
                    break;
                default:
                    break;
            }

            foreach (var item in people)
            {
                if (format.Length == 2)
                {
                    Console.WriteLine($"{item.name} - {item.age}");
                }
                else if (format[0] == "name")
                {
                    Console.WriteLine(item.name);
                }
                else if (format[0] == "age")
                {
                    Console.WriteLine($"{item.age}");
                }
            }
        }
    }
}
