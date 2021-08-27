using System;

namespace DivideWithoutRemainder
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double p1 = 0;
            double p2 = 0;
            double p3 = 0;

            for (int i = 0; i < n; i++)
            {
                double currentNumber = double.Parse(Console.ReadLine());

                if (currentNumber % 2 == 0)
                {
                    p1 += 1;
                }
                if (currentNumber % 3 == 0)
                {
                    p2 += 1;
                }
                if (currentNumber % 4 == 0)
                {
                    p3 += 1;
                }
            }

            double p1Percent = p1 / n * 100;
            double p2Percent = p2 / n * 100;
            double p3Percent = p3 / n * 100;

            Console.WriteLine($"{p1Percent:f2}%");
            Console.WriteLine($"{p2Percent:f2}%");
            Console.WriteLine($"{p3Percent:f2}%");
        }
    }
}
