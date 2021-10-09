using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.GenericSwapMethodIntegers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var list = new List<Box<int>>();

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                var currentBox = new Box<int>(number);
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
