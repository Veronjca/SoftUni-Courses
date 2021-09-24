using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            List<string> people = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();


            Func<List<string>, Func<string, int ,bool>, string> returnName = (x, y) =>
            {
                string name = "";
                foreach (var item in x)
                {
                    bool isTrue = y(item, n);
                    if (isTrue)
                    {
                        name = item;
                        break;
                    }
                }

                return name;
            };


            Func<string, int, bool> sumChars = (x, y) =>
            {
                bool isTrue = false;

                int sum = 0;

                for (int i = 0; i < x.Length; i++)
                {
                    sum += x[i];
                }
                if (sum >= y)
                {
                    isTrue = true;
                }

                return isTrue;

            };

            string result = returnName(people, sumChars);
            Console.WriteLine(result);
        }
    }
}
