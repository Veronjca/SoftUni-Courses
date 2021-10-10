using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.GenericCountMethodDouble
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Box<double>> list = new List<Box<double>>();

            for (int i = 0; i < n; i++)
            {
                double current = double.Parse(Console.ReadLine());
                var currentBox = new Box<double>(current);
                list.Add(currentBox);
            }

            double compareWord = double.Parse(Console.ReadLine());
            Console.WriteLine(Count(list, compareWord));

        }

        public static int Count<T>(List<Box<T>> list, T word)
            where T : IComparable
        {
            list = list.Where(x => x.Value.CompareTo(word) > 0).ToList();

            return list.Count;
        }
    }
}

