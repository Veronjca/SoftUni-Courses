using System;
using System.Collections.Generic;
using System.Linq;

namespace ListsLab
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToList();

            

            List<double> result = new List<double>();

            for (int i = 0; i < i+1; i++)
            {
                if (i + 1 >= numbers.Count)
                {
                    break;
                }

                if (numbers[i] == numbers[i + 1])
                {
                    numbers[i] += numbers[i + 1];
                    numbers.RemoveAt(i + 1);
                    i = -1;
                }

                

            }

            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
