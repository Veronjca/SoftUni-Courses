using System;
using System.Collections.Generic;

namespace _07.HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] childrens = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int toss = int.Parse(Console.ReadLine());

            Queue<string> names = new Queue<string>(childrens);

            while (names.Count > 1)
            {
                for (int i = 1; i < toss ; i++)
                {
                    names.Enqueue(names.Dequeue());
                }

                Console.WriteLine($"Removed {names.Dequeue()}");
            }

            Console.WriteLine($"Last is {names.Dequeue()}");
        }
    }
}
