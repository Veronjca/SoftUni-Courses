using System;

namespace Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

          decimal p1 = 0;
          decimal p2 = 0;
          decimal p3 = 0;
          decimal p4 = 0;
          decimal p5 = 0;

            for (int i = 1; i <= n; i++)
            {
                decimal currentNumber = decimal.Parse(Console.ReadLine());

                if (currentNumber < 200)
                {
                    p1 += 1;
                }
                if (currentNumber >= 200 && currentNumber <= 399)
                {
                    p2 += 1;
                }
                if (currentNumber >= 400 && currentNumber <= 599)
                {
                    p3 += 1;
                }
                if (currentNumber >= 600 && currentNumber <= 799)
                {
                    p4 += 1;
                }
                if (currentNumber >= 800)
                {
                    p5 += 1;
                }
            }

            decimal p1Percent = p1 / n * 100;
            decimal p2Percent = p2 / n * 100;
            decimal p3Percent = p3 / n * 100;
            decimal p4Percent = p4 / n * 100;
            decimal p5Percent = p5 / n * 100;

            Console.WriteLine($"{p1Percent:f2}%");
            Console.WriteLine($"{p2Percent:f2}%");
            Console.WriteLine($"{p3Percent:f2}%");
            Console.WriteLine($"{p4Percent:f2}%");
            Console.WriteLine($"{p5Percent:f2}%");
        }
    }
}
