using System;

namespace OddEvenPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double evenMaxNumber = double.MinValue;
            double evenMinNumber = double.MaxValue;
            double oddMaxNumber = double.MinValue;
            double oddMinNumber = double.MaxValue;
            double oddSum = 0;
            double evenSum = 0;

            for (int i = 1; i <= n; i++)
            {
                double currentNumber = double.Parse(Console.ReadLine());

                if (i % 2 == 0)
                {
                    evenSum += currentNumber;
                    if (currentNumber > evenMaxNumber)
                    {
                        evenMaxNumber = currentNumber;
                    }
                    if (currentNumber < evenMinNumber)
                    {
                        evenMinNumber = currentNumber;
                    }

                }
                if (i % 2 != 0)
                {
                    oddSum += currentNumber;
                    if (currentNumber > oddMaxNumber)
                    {
                        oddMaxNumber = currentNumber;
                    }
                    if (currentNumber < oddMinNumber)
                    {
                        oddMinNumber = currentNumber;
                    }
                }
            }

            Console.WriteLine($"OddSum={oddSum:f2},");
            Console.WriteLine($"OddMin={(oddMinNumber != double.MaxValue ? $"{oddMinNumber:f2}," : "No,")}");
            Console.WriteLine($"OddMax={(oddMaxNumber != double.MinValue ? $"{oddMaxNumber:f2}," : "No,")}");
            Console.WriteLine($"EvenSum={evenSum:f2},");
            Console.WriteLine($"EvenMin={(evenMinNumber != double.MaxValue ? $"{evenMinNumber:f2}," : "No,")}");
            Console.WriteLine($"EvenMax={(evenMaxNumber != double.MinValue ? $"{evenMaxNumber:f2}" : "No")}");

        }
    }
}
