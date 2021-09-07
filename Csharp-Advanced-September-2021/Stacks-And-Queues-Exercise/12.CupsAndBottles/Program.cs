using System;
using System.Collections.Generic;
using System.Linq;

namespace _13.CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cupsCapacity = ReadArrayFromConsole();

            int[] filledBottles = ReadArrayFromConsole();

            Stack<int> cups = new Stack<int>(cupsCapacity.Reverse());
            Stack<int> bottles = new Stack<int>(filledBottles);

            int wastedWater = 0;

            while (cups.Count > 0 && bottles.Count > 0)
            {

                int currentCup = cups.Peek();
                int currentBottle = bottles.Pop();

                if (currentBottle - currentCup > 0)
                {
                    cups.Pop();
                    wastedWater += currentBottle - currentCup;
                }
                else if (currentBottle - currentCup < 0)
                {
                    cups.Pop();
                    cups.Push(Math.Abs(currentBottle - currentCup));

                }
                else
                {
                    cups.Pop();
                }
            }

            if (cups.Count > 0)
            {
                Console.WriteLine($"Cups: {String.Join(" ", cups)}");
            }
            else
            {

                Console.WriteLine($"Bottles: {String.Join(" ", bottles)}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }

        private static int[] ReadArrayFromConsole()
        {
            return Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
