using System;

namespace _03.Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            string command;

            CustomStack<string> stack = new CustomStack<string>();

            while ((command = Console.ReadLine()) != "END")
            {
                string[] commandArgs = command.Split(new string[] {" ", ", " }, StringSplitOptions.RemoveEmptyEntries);

                if (commandArgs[0] == "Push")
                {
                    for (int i = 1; i < commandArgs.Length; i++)
                    {
                        stack.Push(commandArgs[i]);
                    }
                }
                else 
                {
                    stack.Pop();
                }
            }

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
