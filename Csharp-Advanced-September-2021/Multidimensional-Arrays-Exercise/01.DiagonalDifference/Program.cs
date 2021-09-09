using System;
using System.Linq;

namespace Multidimensional_Arrays_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int [] input = ReadArrayFromConsole();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];
                }

            }

            int primaryDiagonalSum = 0;
            int secondaryDiagonalSum = 0;

            int counter = size - 1;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {

                primaryDiagonalSum += matrix[i, i];
                secondaryDiagonalSum += matrix[i, counter];
                counter--;

            }

            int finalSum = Math.Abs(primaryDiagonalSum - secondaryDiagonalSum);

            Console.WriteLine(finalSum);


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
