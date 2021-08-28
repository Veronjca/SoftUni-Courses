using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.AnonymousThreat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command = Console.ReadLine();

            while (command != "3:1")
            {
                string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (commandArgs[0] == "merge")
                {
                    int startIndex = int.Parse(commandArgs[1]);
                    int endIndex = int.Parse(commandArgs[2]);

                    Merge(input, startIndex, endIndex);
                }
                else if (commandArgs[0] == "divide")
                {
                    int index = int.Parse(commandArgs[1]);
                    int partitions = int.Parse(commandArgs[2]);

                    Divide(input, index, partitions);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(String.Join(" ", input));
        }

        private static void Divide(List<string> input, int index, int partitions)
        {

            int partitionLength = input[index].Length / partitions;

            if (input[index].Length < partitions)
            {
                return;
            }

            string result = string.Empty;

            for (int i = 0; i < partitions; i++)
            {
                result += input[index].Substring(0, partitionLength) + " ";
                input[index] = input[index].Remove(0, partitionLength);
            }

            result = result.TrimEnd();
            result += input[index];
            result = result.TrimEnd();
            input.RemoveAt(index);
            input.InsertRange(index, result.Split().ToList());
        }

        private static void Merge(List<string> input, int startIndex, int endIndex)
        {
            if (startIndex < 0)
            {
                startIndex = 0;

            }

            if (endIndex >= input.Count)
            {
                endIndex = input.Count - 1;
            }

            for (int i = startIndex; i < endIndex; i++)
            {
                input[startIndex] += input[startIndex + 1];
                input.RemoveAt(startIndex + 1);
            }
        }
    }
}
