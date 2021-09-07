using System;
using System.Linq;

namespace Multidimensional_Arrays_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSizes = ReadArrayFromConsole();

            int[,] matrix = new int[matrixSizes[0], matrixSizes[1]];

            int sum = 0;

            for (int i = 0; i < matrixSizes[0]; i++)
            {
                int[] input = ReadArrayFromConsole();

                for (int j = 0; j < matrixSizes[1]; j++)
                {
                    matrix[i, j] = input[j];
                }

                sum += input.Sum();
            }

            Console.WriteLine($"{matrixSizes[0]}{Environment.NewLine}{matrixSizes[1]}");
            Console.WriteLine(sum);
        }

        private static int[] ReadArrayFromConsole()
        {
            return Console.ReadLine()
                .Split(new string[] {" ", ", "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
