using System;
using System.Linq;

namespace _03.CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> minNum = n =>
            {
                int min = int.MaxValue;
                for (int j = 0; j < n.Length; j++)
                {
                    if (n[j] < min)
                    {
                        min = n[j];
                    }
                }

                return min;
            };

            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int minValue = minNum(numbers);

            Console.WriteLine(minValue);
                
            
        }
    }
}
