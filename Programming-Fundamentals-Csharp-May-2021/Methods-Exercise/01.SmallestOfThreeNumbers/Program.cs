using System;

namespace MethodsExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            int smallestNumber = GetSmallestNumber(firstNumber, secondNumber, thirdNumber);

            Console.WriteLine(smallestNumber);
        }

        private static int GetSmallestNumber(int firstNumber, int secondNumber, int thirdNumber)
        {


            if (firstNumber > secondNumber && firstNumber > thirdNumber)
            {
                if (secondNumber > thirdNumber)
                {
                    return thirdNumber;
                }

                return secondNumber;

            }
            if (secondNumber > firstNumber && secondNumber > thirdNumber)
            {
                if (firstNumber > thirdNumber)
                {
                    return thirdNumber;
                }

                return firstNumber;

            }
            if (thirdNumber > firstNumber && thirdNumber > secondNumber)
            {
                if (firstNumber > secondNumber)
                {
                    return secondNumber;
                }
            }

            return firstNumber;
        }
    }
}
