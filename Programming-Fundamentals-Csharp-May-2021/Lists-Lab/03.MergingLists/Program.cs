using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MergingLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> first = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> second = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> result = new List<int>();

            if (first.Count < second.Count)
            {
                for (int i = 0; i < first.Count; i++)
                {
                    result.Add(first[i]);
                    result.Add(second[i]);
                }

                for (int i = first.Count; i < second.Count; i++)
                {
                    result.Add(second[i]);
                }
            }
            else
            {
                for (int i = 0; i < second.Count; i++)
                {
                    result.Add(first[i]);
                    result.Add(second[i]);
                }

                for (int i = second.Count; i < first.Count; i++)
                {
                    result.Add(first[i]);
                }
            }

            Console.WriteLine(String.Join(" ", result));
        }
    }
}
