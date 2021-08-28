using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Largest3Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            if (numbers.Count <= 2)
            {
                Console.WriteLine(string.Join(" ", numbers.OrderByDescending(x => x)));
                return;
            }

            for (int i = 0; i < 3; i++)
            {
                int maxNumber = int.MinValue;

                for (int j = 0; j < numbers.Count; j++)
                {
                    if (numbers[j] > maxNumber)
                    {
                        maxNumber = numbers[j];
                    }
                  
                }

                Console.Write($"{maxNumber} ");
                numbers.Remove(maxNumber);
            }
        }
    }
}
