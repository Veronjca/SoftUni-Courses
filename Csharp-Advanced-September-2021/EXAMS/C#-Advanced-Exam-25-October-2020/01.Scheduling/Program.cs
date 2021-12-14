using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> tasks = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> threads = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray().Reverse());
            int taskToKill = int.Parse(Console.ReadLine());

            while (true)
            {
                int currentThread = threads.Pop();
                int currentTask = tasks.Peek();
                if (currentTask == taskToKill)
                {
                    threads.Push(currentThread);
                    break;
                }
                else if (currentThread >= currentTask)
                {
                    tasks.Pop();
                }             
            }

            Console.WriteLine($"Thread with value {threads.Peek()} killed task {taskToKill}");
            Console.WriteLine(string.Join(' ', threads));
        }
    }
}
