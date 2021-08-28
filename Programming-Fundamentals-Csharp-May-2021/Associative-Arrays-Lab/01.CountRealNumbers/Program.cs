using System;
using System.Collections.Generic;
using System.Linq;

namespace AssociativeArraysLab
{
    class Program
    {
        static void Main(string[] args)
        {
            List <double> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToList();


            SortedDictionary<double, double> nums = new SortedDictionary<double, double>();

            for (int i = 0; i < numbers.Count; i++)
            {
                int counter = 0;

                double currentNumber = numbers[i];

                for (int j = 0; j < numbers.Count; j++)
                {
                    if (currentNumber == numbers[j])
                    {
                        counter++;
                    }
                }

                numbers.RemoveAll(x => x == currentNumber);
                i = -1;

                nums.Add(currentNumber, counter);
            }

            nums.OrderByDescending(x => x.Key);

            foreach (var pair in nums)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
            }
        }
    }
}
