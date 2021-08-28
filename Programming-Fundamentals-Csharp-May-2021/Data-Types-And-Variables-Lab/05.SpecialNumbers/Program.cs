using System;

namespace _05.SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            
            for (int i = 1; i <= n ; i++)
            {
                int number = i;

                int sum = 0;

                while (number != 0)
                {
                    sum += number % 10;
                    number /= 10;
                }

                bool ifSpecial = false;


                if (sum == 5 || sum == 7 || sum == 11)
                {
                    ifSpecial = true;
                }

                Console.WriteLine($"{i} -> {ifSpecial}");
            }
        }
    }
}
