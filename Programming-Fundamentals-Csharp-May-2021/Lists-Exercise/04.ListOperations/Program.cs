using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.ListOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (commandArgs[0] == "Remove" )
                {
                    if (int.Parse(commandArgs[1]) < 0 || int.Parse(commandArgs[1]) >= numbers.Count)
                    {
                        Console.WriteLine("Invalid index");
                        command = Console.ReadLine();
                        continue;
                    }                       
                }
                else if (commandArgs[0] == "Insert")
                {
                    if (int.Parse(commandArgs[2]) < 0 || int.Parse(commandArgs[2]) >= numbers.Count)
                    {
                        Console.WriteLine("Invalid index");
                        command = Console.ReadLine();
                        continue;

                    }

                }
               

                if (commandArgs[0] == "Add")
                {
                    numbers.Add(int.Parse(commandArgs[1]));
                }
                else if (commandArgs[0] == "Insert")
                {
                    numbers.Insert(int.Parse(commandArgs[2]), int.Parse(commandArgs[1]));
                }
                else if (commandArgs[0] == "Remove")
                {
                    numbers.RemoveAt(int.Parse(commandArgs[1]));
                }
                else if (commandArgs[1] == "left")
                {
                    ShiftLeft(numbers, int.Parse(commandArgs[2]));
                }
                else if (commandArgs[1] == "right")
                {
                    ShiftRight(numbers, int.Parse(commandArgs[2]));
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(String.Join(" ", numbers));
        }

        private static void ShiftRight(List<int> numbers, int rotations)
        {
            for (int i = 0; i < rotations; i++)
            {
                int firstNumber = numbers[numbers.Count - 1];
                numbers.RemoveAt(numbers.Count-1);
                numbers.Insert(0, firstNumber);
            }
        }

        private static void ShiftLeft(List<int> numbers, int rotations)
        {
            for (int i = 0; i < rotations; i++)
            {
                int lastNumber = numbers[0];
                numbers.RemoveAt(0);
                numbers.Add(lastNumber);
            }
        }
    }
}
