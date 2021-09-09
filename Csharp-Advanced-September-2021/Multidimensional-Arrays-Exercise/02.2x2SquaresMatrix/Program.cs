using System;
using System.Linq;

namespace _02._2x2SquaresMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = ReadArrayFromConsole();

            int[,] matrix = new int[sizes[0], sizes[1]];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] input = ReadCharArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];
                }

            }

            int counter = 0;

            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {

                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    if (matrix[i, j] == matrix[i, j + 1] && matrix[i, j] == matrix[i + 1, j] && matrix[i, j] == matrix[i + 1, j + 1])
                    {
                        counter++;
                    }

                }
            }

            Console.WriteLine(counter);
        }

        private static char[] ReadCharArray()
        {
            return Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();
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
