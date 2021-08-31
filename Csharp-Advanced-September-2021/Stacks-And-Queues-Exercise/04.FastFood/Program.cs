using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());

            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> orders = new Stack<int>(input.Reverse());

            for (int i = 0; i < input.Length; i++)
            {
                foodQuantity -= orders.Peek();

                if (foodQuantity >= 0)
                {
                    orders.Pop();
                }
                else
                {
                    break; 
                }
            }

            Console.WriteLine(input.Max());

            if (orders.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {String.Join(" ", orders)}");
            }
        }
    }
}
