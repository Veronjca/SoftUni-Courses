using System;

namespace _02.Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int num = 0;

            if (number % 2 == 0)
            {
                num = 2;
            }
            if (number % 3 == 0)
            {
                num = 3;
            }
            if (number % 6 == 0)
            {
                num = 6;
            }
            if (number % 7 == 0)
            {
                num = 7;
            }
            if (number % 10 == 0)
            {
                num = 10;
            }
            if (number % 2 != 0 && number % 3 != 0 && number % 6 != 0 && number % 7 != 0 && number % 10 != 0)
            {
                Console.WriteLine("Not divisible");
                return;
            }

            Console.WriteLine($"The number is divisible by {num}");
        }
    }
}
