using System;
using System.Linq;

namespace Functional_Programming_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> print = s => Console.WriteLine(s);

            Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(print);
        }
    }
}
