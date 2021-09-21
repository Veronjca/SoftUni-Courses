using System;
using System.Linq;

namespace _03.CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> uppercase = w => char.IsUpper(w[0]);

            Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Where(uppercase)
                .ToList()
                .ForEach(w => Console.WriteLine(w));
        }
    }
}
