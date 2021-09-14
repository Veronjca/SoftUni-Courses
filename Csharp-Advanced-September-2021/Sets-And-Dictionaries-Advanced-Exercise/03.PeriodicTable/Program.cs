using System;
using System.Collections.Generic;

namespace _03.PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            SortedSet<string> table = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] elements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < elements.Length; j++)
                {
                    table.Add(elements[j]);
                }
            }

            Console.WriteLine($"{String.Join(" ", table)}");
        }
    }
}
