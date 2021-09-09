using System;
using System.Linq;

namespace _04.MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = ReadArrayFromConsole();

            string[,] matrix = new string[sizes[0], sizes[1]];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            string command = Console.ReadLine()?.ToUpper();

            while (command != "END")
            {
                string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (commandArgs[0] != "SWAP" || commandArgs.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                    command = Console.ReadLine()?.ToUpper();
                    continue;

                }

                int firstRow = int.Parse(commandArgs[1]);
                int firstCol = int.Parse(commandArgs[2]);
                int secondRow = int.Parse(commandArgs[3]);
                int secondCol = int.Parse(commandArgs[4]);

               
                if (firstRow < 0 || firstRow >= sizes[0] || firstCol < 0 || firstCol >= sizes[1] || secondRow < 0 || secondRow >= sizes[0] || secondCol < 0 || secondCol >= sizes[1])
                {
                    Console.WriteLine("Invalid input!");
                    command = Console.ReadLine()?.ToUpper();
                    continue;
                }

                string temp = matrix[firstRow, firstCol];

                matrix[firstRow, firstCol] = matrix[secondRow, secondCol];
                matrix[secondRow, secondCol] = temp;

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        Console.Write($"{matrix[i,j]} ");
                    }

                    Console.WriteLine();
                }

                
                command = Console.ReadLine()?.ToUpper();
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
