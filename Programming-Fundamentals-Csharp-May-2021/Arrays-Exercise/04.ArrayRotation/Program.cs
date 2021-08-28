using System;
using System.Linq;

namespace _04.ArrayRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rotations = int.Parse(Console.ReadLine());

          

            for (int i = 0; i < rotations; i++)
            {
                int firstElement = numbers[0];
                for (int j = 0; j < numbers.Length - 1; j++)
                {
                    
                   numbers[j] = numbers[j + 1];
                                       
                }

                numbers[numbers.Length - 1] = firstElement;

            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
