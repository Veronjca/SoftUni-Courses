using System;

namespace FromLeftToTheRight
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] input = Console.ReadLine().Split();

                long sum = 0;
                long firstNumber = long.Parse(input[0]);
                long secondNumber = long.Parse(input[1]);

                if (firstNumber > secondNumber)
                {
                    foreach (var a in input[0])
                    {
                        long.TryParse(a.ToString(), out long digit);
                        sum += digit;
                            
                    }
                }
                else
                {
                    foreach (var a in input[1])
                    {
                        long.TryParse(a.ToString(), out long digit);
                        sum += digit;
                    }
                }

                Console.WriteLine(sum);
            }
        }
    }
}
