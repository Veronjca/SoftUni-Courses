using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.ListManipulationBasics
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

            while(command != "end")
            {
                string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (commandArgs[0] == "Add")
                {
                    numbers.Add(int.Parse(commandArgs[1]));
                }
                else if (commandArgs[0] == "Remove")
                {
                    numbers.Remove(int.Parse(commandArgs[1]));
                }
                else if (commandArgs[0] == "RemoveAt" )
                {
                    numbers.RemoveAt(int.Parse(commandArgs[1]));
                }
                else if (commandArgs[0] == "Insert")
                {
                    numbers.Insert(int.Parse(commandArgs[2]), int.Parse(commandArgs[1]));
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
