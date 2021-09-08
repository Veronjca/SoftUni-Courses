using System;
using System.Linq;

namespace _06.JaggedArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] jagged = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                int[] input = ReadArrayFromConsole();
                jagged[i] = input;
            }

            string command = Console.ReadLine()?.ToUpper();

            while (command != "END")
            {
                string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int row = int.Parse(commandArgs[1]);
                int col = int.Parse(commandArgs[2]);

                if (row < 0 || row >= rows || col < 0 || col >= jagged[row].Length)
                {
                    Console.WriteLine("Invalid coordinates");

                    command = Console.ReadLine()?.ToUpper();
                    continue;
                }
                if (commandArgs[0] == "ADD")
                {
                    jagged[row][col] += int.Parse(commandArgs[3]);
                }
                else if (commandArgs[0] == "SUBTRACT")
                {
                    jagged[row][col] -= int.Parse(commandArgs[3]);
                }

                command = Console.ReadLine()?.ToUpper();

            }

            foreach (var item in jagged)
            {
                for (int i = 0; i < item.Length; i++)
                {
                    Console.Write($"{item[i]} ");
                }

                Console.WriteLine();
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
