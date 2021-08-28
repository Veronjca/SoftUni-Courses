using System;
using System.Linq;

namespace _10.PairsByDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

            int difference = int.Parse(Console.ReadLine());
            int counter = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (Math.Abs(numbers[i] - numbers[j]) == difference)
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine(counter);
        }
    }
}
