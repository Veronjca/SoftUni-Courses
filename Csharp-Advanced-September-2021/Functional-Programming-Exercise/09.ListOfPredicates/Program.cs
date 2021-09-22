using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] dividers = ReadArrayFromConsole();

            Func<int[], int, List<int>> numbers = (x, n) =>
            {
                List<int> result = new List<int>();

                for (int i = 1; i <= n; i++)
                {
                    int counter = 0;

                    for (int j = 0; j < x.Length; j++)
                    {
                        if (i % x[j] == 0)
                        {
                            counter++;
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (counter == x.Length)
                    {
                        result.Add(i);
                    }
                }

                return result;
            };

            List<int> final = numbers(dividers, n);

            Console.WriteLine(String.Join(" ", final));
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
