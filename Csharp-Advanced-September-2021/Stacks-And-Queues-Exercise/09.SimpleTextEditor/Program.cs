using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace _09.SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {

            StringBuilder text = new StringBuilder();

            Stack<string> lastCommand = new Stack<string>();

            lastCommand.Push(text.ToString());

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                List<string> currentCommand = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();


                if (currentCommand[0] == "1")
                {
                    text.Append(currentCommand[1]);
                    lastCommand.Push(text.ToString());
                }
                else if (currentCommand[0] == "2")
                {
                    int count = int.Parse(currentCommand[1]);
                   
                    text = text.Remove(text.Length - count, count);

                    lastCommand.Push(text.ToString());
                }
                else if (currentCommand[0] == "3")
                {
                    int index = int.Parse(currentCommand[1]) - 1;

                    Console.WriteLine(text.ToString().ElementAt(index));
                }
                else if (currentCommand[0] == "4")
                {
                    lastCommand.Pop();
                    text = new StringBuilder();
                    text.Append(lastCommand.Peek());
                }

            }
        }
    }
}
