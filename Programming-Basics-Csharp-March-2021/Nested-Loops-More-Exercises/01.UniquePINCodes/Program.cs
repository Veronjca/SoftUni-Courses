using System;

namespace NestedLoopsMoreExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            int upperLimitFirstNumber = int.Parse(Console.ReadLine());
            int upperLimitSecondNumber = int.Parse(Console.ReadLine());
            int upperLimitThirdNumber = int.Parse(Console.ReadLine());


            // Първата и третата цифра трябва да бъдат четни.
            //Втората цифра трябва да бъде просто число в диапазона[2...7].



            for (int i = 2; i <= upperLimitFirstNumber; i++)
            {
                for (int j = 2; j <= upperLimitSecondNumber; j++)
                {
                    for (int k = 2; k <= upperLimitThirdNumber; k++)
                    {
                        if (i % 2 == 0)
                        {
                            if (j == 2 || j == 3 || j == 5 || j == 7)
                            {
                                if (k % 2 == 0)
                                {
                                    Console.WriteLine($"{i} {j} {k}");
                                }
                            }
                        }
                    }

                }


            }

        }
    }
}

