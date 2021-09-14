using System;
using System.Collections.Generic;

namespace _04.EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, int> counter = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                string number = Console.ReadLine();

                if (counter.ContainsKey(number))
                {
                    counter[number]++;
                }
                else
                {
                    counter.Add(number, 1);
                }
            }

            foreach (var item in counter)
            {
                if (item.Value % 2 == 0)
                {
                    Console.WriteLine($"{item.Key}");
                }
            }
        }
    }
}
