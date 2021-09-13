using System;
using System.Collections.Generic;
using System.Linq;

namespace Sets_And_Dictionaries_Advanced_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> counter = new Dictionary<string, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (counter.ContainsKey(numbers[i]))
                {
                    counter[numbers[i]]++;
                }
                else
                {
                    counter.Add(numbers[i], 1);
                }
            }

            foreach (var item in counter)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}
