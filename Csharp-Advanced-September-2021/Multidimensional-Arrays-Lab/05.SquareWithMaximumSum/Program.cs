using System;
using System.Linq;

namespace _05.SquareWithMaximumSum
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

            int maxSum = 0;
            int maxRow = int.MinValue;
            int maxCol = int.MinValue;

            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                int sum = 0;

                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    sum = matrix[i, j] +
                        matrix[i, j + 1] +
                        matrix[i + 1, j] +
                        matrix[i + 1, j + 1];

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        maxRow = i;
                        maxCol = j;
                    }
                }
             
            }

            Console.WriteLine($"{matrix[maxRow, maxCol]} {matrix[maxRow, maxCol + 1]}{ Environment.NewLine}{matrix[maxRow+1, maxCol]} {matrix[maxRow+1, maxCol+1]}{Environment.NewLine}{maxSum}");

        }

        public static int[] ReadArrayFromConsole()
        {
            return Console.ReadLine()
                .Split(new string[] { " ", ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
