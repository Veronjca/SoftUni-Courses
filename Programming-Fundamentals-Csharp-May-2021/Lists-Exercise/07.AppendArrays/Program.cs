using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.AppendArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            input.Reverse();

            string result = string.Empty;

            for (int i = 0; i < input.Count; i++)
            {
                result += input[i] + " ";
            }

            string[] resultArray = result.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            Console.WriteLine(String.Join(" ", resultArray));
                
        }
    }
}
