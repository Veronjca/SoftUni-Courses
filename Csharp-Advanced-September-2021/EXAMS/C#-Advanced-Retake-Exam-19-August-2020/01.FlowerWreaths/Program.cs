using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> lilies = new Stack<int>(ReadArrayFromConsole());
            Queue<int> roses = new Queue<int>(ReadArrayFromConsole());
            int wreaths = 0;

            int storedFlowers = 0;

            while (lilies.Count > 0 && roses.Count > 0)
            {
                int rose = roses.Peek();
                int lili = lilies.Pop();
                int sum = rose + lili;
                if (sum == 15)
                {
                    wreaths++;
                    roses.Dequeue();
                }
                else if (sum > 15)
                {
                    lili-=2;
                    lilies.Push(lili);
                    continue;
                }
                else
                {
                    roses.Dequeue();
                    storedFlowers += sum;
                }
            }

            wreaths += Math.Abs(storedFlowers / 15);
            Console.WriteLine(wreaths >= 5 ? $"You made it, you are going to the competition with {wreaths} wreaths!" : $"You didn't make it, you need {5 - wreaths} wreaths more!");
        }

        private static IEnumerable<int> ReadArrayFromConsole()
        {
            return Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
        }
    }
}
