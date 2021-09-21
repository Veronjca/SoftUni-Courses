using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FindEvenOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], string> odds = n =>
            {
                List<int> oddNums = new List<int>();

                for (int i = n[0]; i < n[1]; i++)
                {
                    if (i % 2 != 0)
                    {
                        oddNums.Add(i);
                    }
                }

                return String.Join(" ", oddNums);
            };

            Func<int[], string> evens = n =>
            {
                List<int> evenNums = new List<int>();

                for (int i = n[0]; i < n[1]; i++)
                {
                    if (i % 2 == 0)
                    {
                        evenNums.Add(i);
                    }
                }

                return String.Join(" ", evenNums);
            };

           int[] constraints = ReadArrayFromConsole();
            string command = Console.ReadLine();

            switch (command)
            {
                case "odd":
                    Console.WriteLine(odds(constraints));
                    break;
                case "even":
                    Console.WriteLine(evens(constraints));
                    break;
                default:
                    break;
            }
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
