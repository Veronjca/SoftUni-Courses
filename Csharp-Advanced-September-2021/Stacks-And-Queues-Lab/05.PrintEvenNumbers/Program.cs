using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<string> nums = new Queue<string>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    nums.Enqueue(numbers[i].ToString());
                }
            }

            Console.WriteLine(string.Join(", ", nums));
        }
    }
}
