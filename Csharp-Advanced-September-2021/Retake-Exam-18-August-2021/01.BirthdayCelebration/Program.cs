using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BirthdayCelebration
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> guestsCapacity = new Stack<int>(ReadArrayFromConsole().Reverse());
            Stack<int> plates = new Stack<int>(ReadArrayFromConsole());

            int wastedFood = 0;

            while (guestsCapacity.Count > 0 && plates.Count > 0)
            {

                int currentCup = guestsCapacity.Peek();
                int currentBottle = plates.Pop();

                if (currentBottle - currentCup > 0)
                {
                    guestsCapacity.Pop();
                    wastedFood += currentBottle - currentCup;
                }
                else if (currentBottle - currentCup < 0)
                {
                    guestsCapacity.Pop();
                    guestsCapacity.Push(Math.Abs(currentBottle - currentCup));

                }
                else
                {
                    guestsCapacity.Pop();
                }
            }

            if (guestsCapacity.Count > 0)
            {
                Console.WriteLine($"Guests: {String.Join(" ", guestsCapacity)}");
            }
            else
            {

                Console.WriteLine($"Plates: {String.Join(" ", plates)}");
            }

            Console.WriteLine($"Wasted grams of food: {wastedFood}");
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

