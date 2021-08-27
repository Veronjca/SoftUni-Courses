using System;

namespace Sequence2K_1
{
    class Program
    {
        static void Main(string[] args)
        {
            double n = double.Parse(Console.ReadLine());

            double number = 1;

            while (number <= n)
            {
                Console.WriteLine(number);
                number = number * 2 + 1;

            }
        }
    }
}
