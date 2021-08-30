using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> stackNumbers = new Stack<int>(numbers);

            string command = Console.ReadLine().ToLower();

            while (command != "end")
            {
                string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (commandArgs[0] == "add")
                {
                    stackNumbers.Push(int.Parse(commandArgs[1]));
                    stackNumbers.Push(int.Parse(commandArgs[2]));
                }
                else if (commandArgs[0] == "remove")
                {
                    if (stackNumbers.Count >= int.Parse(commandArgs[1]))
                    {
                        for (int i = 0; i < int.Parse(commandArgs[1]); i++)
                        {
                            stackNumbers.Pop();
                        }
                    }
                    
                }

                command = Console.ReadLine().ToLower();
            }

            Console.WriteLine($"Sum: {stackNumbers.Sum()}");
        }
    }
}
