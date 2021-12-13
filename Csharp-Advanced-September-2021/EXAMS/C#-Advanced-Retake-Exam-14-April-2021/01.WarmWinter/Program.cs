using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.WarmWinter
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> hats = new Stack<int>(ReadArrayFromConsole());
            Queue<int> scarfs = new Queue<int>(ReadArrayFromConsole());

            List<int> sets = new List<int>();
            while (hats.Count > 0 && scarfs.Count > 0)
            {
                int hat = hats.Pop();
                int scarf = scarfs.Peek();
                if (hat > scarf)
                {
                    int set = hat + scarf;
                    scarfs.Dequeue();
                    sets.Add(set);
                }
                else if (scarf == hat)
                {
                    scarfs.Dequeue();
                    hat += 1;
                    hats.Push(hat);
                }
            }

            Console.WriteLine($"The most expensive set is: {sets.Max()}");
            Console.WriteLine(string.Join(' ', sets));
        }

        private static IEnumerable<int> ReadArrayFromConsole()
        {
            return Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
        }
    }
}
