using System;

namespace _03.RoundingNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < numbers.Length; i++)
            {
                double number = double.Parse(numbers[i]);

                if (number == -0)
                {
                    number = 0;
                }
                double result = Math.Round(number, MidpointRounding.AwayFromZero);

                Console.WriteLine($"{number} => {(int)result}");
                
            }
        }
    }
}
