using System;
using System.Linq;

namespace _05.AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = ReadArrayFromConsole();

            string command = Console.ReadLine();

            Action<int[]> print = x => Console.WriteLine(String.Join(" ", x));

            while (command != "end")
            {
                switch (command)
                {
                    case "add":
                        input = input.Select(x => x + 1).ToArray();
                        break;
                    case "multiply":
                        input = input.Select(x => x * 2).ToArray();
                        break;
                    case "subtract":
                        input = input.Select(x => x - 1).ToArray();
                        break;
                    case "print":
                        print(input);
                        break;
                    default:
                        break;
                }

                command = Console.ReadLine();
            }
        }

        private static int[] ReadArrayFromConsole()
        {
            return Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
