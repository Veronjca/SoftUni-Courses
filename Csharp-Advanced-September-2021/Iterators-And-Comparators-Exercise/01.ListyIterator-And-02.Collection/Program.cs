using System;
using System.Collections.Generic;

namespace _01.ListyIterator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string command = Console.ReadLine();
            string[] commandArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            List<string> temp = new List<string>();

            if (commandArgs.Length > 1)
            {
                for (int i = 1; i < commandArgs.Length; i++)
                {
                    temp.Add(commandArgs[i]);
                }
            }
            ListyIterator<string> current = new ListyIterator<string>(temp.ToArray());

            while ((command = Console.ReadLine()) != "END")
            {
                if (command == "Move")
                {
                    Console.WriteLine(current.Move()); 
                }
                else if (command == "Print")
                {
                    current.Print();
                }
                else if (command == "HasNext")
                {
                    Console.WriteLine(current.HasNext());
                }
                else if (command == "PrintAll")
                {
                    current.PrintAll();
                }
            }
        }
    }
}
