using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _06.ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int, List<int>> removed = (x, n) =>
            {
                List<int> result = new List<int>();

                for (int i = 0; i < x.Length; i++)
                {
                    if (x[i] % n != 0)
                    {
                        result.Add(x[i]);
                    }
                }
                return result;
            };

            int[] input = Console.ReadLine()
                         .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                         .Select(int.Parse)
                         .ToArray()
                         .Reverse()
                         .ToArray();

            int n = int.Parse(Console.ReadLine());

            List<int> result = removed(input, n).ToList();

            Console.WriteLine(String.Join(" ", result));
            


        }
    }
}
