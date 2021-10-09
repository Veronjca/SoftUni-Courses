using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.GenericSwapMethodStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Box<string>> list = new List<Box<string>>();

            for (int i = 0; i < n; i++)
            {
                string currentString = Console.ReadLine();
                Box<string> currentBox = new Box<string>(currentString);
                list.Add(currentBox);
            }

            int[] indexes = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Swap(list, indexes);
            list.ForEach(x => Console.WriteLine(x));

        }

        public static void Swap<T>(List<T> input, int[] indexes)
        {
            T firstString = input[indexes[0]];
            T secondString = input[indexes[1]];

            input[indexes[0]] = secondString;
            input[indexes[1]] = firstString;
        }
    }
}
