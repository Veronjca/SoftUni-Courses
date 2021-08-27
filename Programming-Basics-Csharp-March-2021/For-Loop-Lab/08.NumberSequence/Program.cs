using System;

namespace NumberSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbersQuantity = int.Parse(Console.ReadLine());
            
            int maxNumber = int.MinValue;
            int minNumber = int.MaxValue;

            int currentNumber = 0;

            for (int i = 0; i < numbersQuantity; i++)
            {

               currentNumber = int.Parse(Console.ReadLine());

                if (currentNumber > maxNumber)
                {
                    maxNumber = currentNumber;
                }
                if (currentNumber < minNumber)
                {
                    minNumber = currentNumber;
                }

            }

            Console.WriteLine($"Max number: {maxNumber}");
            Console.WriteLine($"Min number: {minNumber}");
           

        }
    }
}
