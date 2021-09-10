using System;
using System.Linq;

namespace _06.JaggedArrayManipulator
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

            for (int i = 0; i <= rows - 2; i++)
            {
               
                if (jagged[i].Length == jagged[i+1].Length)
                {
                    jagged[i] = jagged[i].Select(x => x * 2).ToArray();
                    jagged[i + 1] = jagged[i + 1].Select(x => x * 2).ToArray();
                }
                else
                {
                    jagged[i] = jagged[i].Select(x => x / 2).ToArray();
                    jagged[i + 1] = jagged[i + 1].Select(x => x / 2).ToArray();
                }
            }

            string command = Console.ReadLine()?.ToUpper();

            while (command != "END")
            {
                string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int row = int.Parse(commandArgs[1]);
                int col = int.Parse(commandArgs[2]);
                int value = int.Parse(commandArgs[3]);

                if (row < 0 || row >= rows || col < 0 || col >= jagged[row].Length)
                {
                    command = Console.ReadLine()?.ToUpper();
                    continue;
                }
                else if(commandArgs[0] == "ADD")
                {
                    jagged[row][col] += value;
                }
                else if (commandArgs[0] == "SUBTRACT")
                {
                    jagged[row][col] -= value;
                }

                command = Console.ReadLine()?.ToUpper();
            }

            foreach (var item in jagged)
            {
                Console.WriteLine(String.Join(" ", item));
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
