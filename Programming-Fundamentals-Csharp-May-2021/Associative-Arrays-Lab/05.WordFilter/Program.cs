using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.WordFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            words = words.Where(x => x.Length % 2 == 0).ToList();

            foreach (var word in words)
            {
                Console.WriteLine($"{word}");
            }


        }
    }
}
