using System;

namespace EqualSumsEvenOddPositions
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            // always firstNumber < secondNumber

            for (int i = firstNumber; i <= secondNumber; i++)
            {
                string currentNumber = i.ToString();

                int evenSum = 0;
                int oddSum = 0;


                for (int j = 0; j < currentNumber.Length; j++)
                {
                    int currentDigit = int.Parse(currentNumber[j].ToString());

                    if (j % 2 == 0)
                    {
                        evenSum += currentDigit;
                        
                    }
                    else
                    {
                        oddSum += currentDigit;
                    }
                }

                if (oddSum == evenSum)
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
}
