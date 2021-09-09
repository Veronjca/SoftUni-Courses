using System;
using System.Linq;

namespace _03.MaxSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = ReadArrayFromConsole();

            int[,] matrix = new int[sizes[0], sizes[1]];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] input = ReadArrayFromConsole();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];
                }

            }

            int maxSum = int.MinValue;
            int maxRow = int.MinValue;
            int maxCol = int.MinValue;

            for (int i = 0; i < matrix.GetLength(0) - 2; i++)
            {
                int sum = 0;

                for (int j = 0; j < matrix.GetLength(1) - 2; j++)
                {
                    sum = matrix[i, j] +
                        matrix[i, j + 1] +
                        matrix[i, j + 2] +
                        matrix[i + 1, j] +
                        matrix[i + 1, j + 1] +
                        matrix[i + 1, j + 2] +
                        matrix[i + 2, j] +
                        matrix[i + 2, j + 1] +
                        matrix[i + 2, j + 2];

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        maxRow = i;
                        maxCol = j;
                    }
                }

            }

            Console.WriteLine($"Sum = {maxSum}");

            Console.WriteLine($"{matrix[maxRow, maxCol]} {matrix[maxRow, maxCol + 1]} {matrix[maxRow, maxCol + 2]}");
            Console.WriteLine($"{matrix[maxRow + 1, maxCol]} {matrix[maxRow + 1, maxCol + 1]} {matrix[maxRow + 1, maxCol + 2]}");
            Console.WriteLine($"{matrix[maxRow + 2, maxCol]} {matrix[maxRow + 2, maxCol + 1]} {matrix[maxRow + 2, maxCol + 2]}");
        }

        private static int[] ReadArrayFromConsole()
        {
            return Console.ReadLine()
                .Split(new string[] { " ", ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
