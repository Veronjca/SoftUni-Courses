using System;
using System.Collections.Generic;

namespace _06.EqualityLogic
{
    public class Program
    {
        static void Main(string[] args)
        {
            HashSet<Person> hashset = new HashSet<Person>();
            SortedSet<Person> sorted = new SortedSet<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                hashset.Add(new Person(input[0], int.Parse(input[1])));
                sorted.Add(new Person(input[0], int.Parse(input[1])));
            }

            Console.WriteLine($"{hashset.Count}\n{sorted.Count}");
        }
    }
}
