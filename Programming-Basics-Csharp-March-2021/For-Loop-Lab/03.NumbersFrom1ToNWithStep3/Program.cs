using System;

namespace NumbersN1
{
    class Program
    {
        static void Main(string[] args)
        {
            double n = double.Parse(Console.ReadLine());

            for (double i = 1; i <= n; i += 3)
            {
                Console.WriteLine(i);

            }
        }
    }
}
