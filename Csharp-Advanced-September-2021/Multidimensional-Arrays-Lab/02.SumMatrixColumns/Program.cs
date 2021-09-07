using System;
using System.Linq;

namespace _02.SumMatrixColumns
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSizes = ReadArrayFromConsole();

            int[,] matrix = new int[matrixSizes[0], matrixSizes[1]];

            for (int i = 0; i < matrixSizes[0]; i++)
            {
                int[] input = ReadArrayFromConsole();

                for (int j = 0; j < matrixSizes[1]; j++)
                {
                    matrix[i, j] = input[j];
                }

            }

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                int sum = 0;

                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    sum += matrix[j, i];
                }

                Console.WriteLine(sum);
            }

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
