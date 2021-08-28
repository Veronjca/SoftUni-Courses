using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ChangeList
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

            while (command != "end")
            {
                string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                switch (commandArgs[0])
                {
                    case "Delete":
                        numbers.RemoveAll(x => x == int.Parse(commandArgs[1]));
                        break;
                    case "Insert":
                        numbers.Insert(int.Parse(commandArgs[2]), int.Parse(commandArgs[1]));
                        break;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
