using System;

namespace EvenOrOdd
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            double result = number % 2;

            if (result == 0)
            {
                Console.WriteLine("even");
            }

            if (result != 0)
                {
                    Console.WriteLine("odd");
                }

        }
    }
}
