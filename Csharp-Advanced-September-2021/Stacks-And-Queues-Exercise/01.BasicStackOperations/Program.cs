using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacks_And_Queues_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] commands = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] numbers = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            Stack<int> nums = new Stack<int>(numbers);

            for (int i = 0; i < commands[1]; i++)
            {
                nums.Pop();
            }

           bool isContains = nums.Contains(commands[2]);

            if (nums.Count == 0)
            {
                Console.WriteLine("0");
                return;
            }

            if (isContains)
            {
                Console.WriteLine("true");
            }
            else 
            {
                Console.WriteLine(nums.Min()); 
            }
        }
    }
}
