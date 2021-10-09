using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.GenericCountMethodStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Box<string>> list = new List<Box<string>>();

            for (int i = 0; i < n; i++)
            {
                string current = Console.ReadLine();
                var currentBox = new Box<string>(current);
                list.Add(currentBox);
            }

            string compareWord = Console.ReadLine();
            Console.WriteLine(Count(list, compareWord)); 
            
        }        

        public static int Count<T>(List<Box<T>> list, T word)
            where T: IComparable
        {
            list = list.Where(x => x.Value.CompareTo(word) > 0).ToList();

           
            return list.Count;
        }
    }
}
