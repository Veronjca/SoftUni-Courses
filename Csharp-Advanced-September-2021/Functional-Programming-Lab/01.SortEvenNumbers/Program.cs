using System;
using System.Linq;

namespace Functional_Programming_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, bool> even = n => n % 2 == 0;

            int[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(even)
                .OrderBy(n => n)
                .ToArray();

            Console.WriteLine(string.Join(", ", input));
        }
    }
}
