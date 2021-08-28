using System;

namespace _10.MultiplyEvensByOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = Math.Abs(int.Parse(Console.ReadLine()));


            int sumOfEvenDigits = GetEvenDigitsSum(number.ToString());
            int sumOfOddDigits = GetOddDigitsSum(number.ToString());
            int multipleOfEvenSumAndOddSum = GetMutipleOfEvenSumAndOddSum(sumOfEvenDigits, sumOfOddDigits);

            Console.WriteLine(multipleOfEvenSumAndOddSum);
        }

        private static int GetMutipleOfEvenSumAndOddSum(int sumOfEvenDigits, int sumOfOddDigits)
        {
            int result = sumOfEvenDigits * sumOfOddDigits;

            return result;
        }

        private static int GetOddDigitsSum(string number)
        {
            int oddSum = 0;

            for (int i = 0; i < number.Length; i++)
            {
                int currentDigit = int.Parse(number[i].ToString());

                if (currentDigit % 2 != 0)
                {
                    oddSum += currentDigit;
                }
            }

            return oddSum;
        }

        private static int GetEvenDigitsSum(string number)
        {
            int evenSum = 0;

            for (int i = 0; i < number.Length; i++)
            {
                int currentDigit = int.Parse(number[i].ToString());

                if (currentDigit % 2 == 0)
                {
                    evenSum += currentDigit;
                }
            }

            return evenSum;
        }
    }
}
