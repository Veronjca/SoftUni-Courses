using System;
using System.Linq;
using System.Collections.Generic;

namespace _02.BasicQueueOperations
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

                Queue<int> nums = new Queue<int>(numbers);

                for (int i = 0; i < commands[1]; i++)
                {
                    nums.Dequeue();
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


   
