using System;
using System.Collections.Generic;

namespace Stacks_And_Queues_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> reversed = new Stack<char>(input);

            while (reversed.Count > 0)
            {
                Console.Write(reversed.Pop()); 
            }
        }
    }
}
