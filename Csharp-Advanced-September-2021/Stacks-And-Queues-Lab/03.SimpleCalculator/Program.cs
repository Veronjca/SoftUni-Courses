using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Stack<string> expression = new Stack<string>(input.Reverse());

            while (expression.Count > 1)
            {
                int a = int.Parse(expression.Pop());
                string @operator = expression.Pop();
                int b = int.Parse(expression.Pop());

                if (@operator == "-")
                {
                    expression.Push((a - b).ToString());
                }
                else if (@operator == "+") 
                {
                    expression.Push((a + b).ToString());
                }
            }

            Console.WriteLine(expression.Pop());
        }
    }
}
