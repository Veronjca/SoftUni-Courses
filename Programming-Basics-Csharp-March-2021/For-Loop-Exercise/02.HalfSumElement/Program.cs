using System;

namespace HalfSumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());


            int maxNumber = int.MinValue;
            int sum = 0;

            for (int i = 1; i <= number; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                sum += currentNumber;
                if (currentNumber > maxNumber)
                {
                    maxNumber = currentNumber;
                }
            }

            int sumWithoutMaxNumber = sum - maxNumber;

            if (sumWithoutMaxNumber == maxNumber)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {maxNumber}");
            }
            else
            {
                int diff = maxNumber - sumWithoutMaxNumber;
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(diff)}");
            }

        }
    }
}
