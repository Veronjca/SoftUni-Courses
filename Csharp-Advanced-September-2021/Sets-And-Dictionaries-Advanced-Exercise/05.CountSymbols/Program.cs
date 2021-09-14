using System;
using System.Collections.Generic;

namespace _05.CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();

            SortedDictionary<char, int> counter = new SortedDictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                

                if (counter.ContainsKey(input[i]))
                {
                    counter[input[i]]++;
                }
                else
                {
                    counter.Add(input[i], 1);
                }
            }

            foreach (var item in counter)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
