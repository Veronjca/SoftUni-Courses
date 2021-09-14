using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int [] lengths = ReadArrayFromConsole();
            int n = lengths[0];
            int m = lengths[1];

            HashSet<int> first = new HashSet<int>();
            HashSet<int> second = new HashSet<int>();

            for (int i = 0; i < n+m; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (i <= n-1)
                {
                    first.Add(number);
                }
                else
                {
                    second.Add(number);
                }
            }

            HashSet<int> matches = new HashSet<int>();

            foreach (var item in first)
            {
                if (second.Contains(item))
                {
                    matches.Add(item);
                }
            }

            Console.WriteLine($"{String.Join(" ", matches)}");
        }

        private static int[] ReadArrayFromConsole()
        {
            return Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
