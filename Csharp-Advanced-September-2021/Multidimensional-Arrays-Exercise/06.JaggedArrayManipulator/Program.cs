using System;
using System.Linq;

namespace _06.JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            byte rows = byte.Parse(Console.ReadLine());

            double[][] jagged = new double[rows][];

            for (int i = 0; i < rows; i++)
            {
                double[] input = ReadArrayFromConsole();
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
                double value = double.Parse(commandArgs[3]);

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
        private static double[] ReadArrayFromConsole()
        {
            return Console.ReadLine()
                .Split(new string[] { " ", ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();
        }
    }
}
