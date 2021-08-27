using System;

namespace SumPrimeNonPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();

            int primeNumbersSum = 0;
            int nonPrimeNumbersSum = 0;

            while (number != "stop")
            {
                int currentNumber = int.Parse(number);
                bool ifNonPrime = false;

                if (currentNumber < 0)
                {
                    Console.WriteLine("Number is negative.");
                    number = Console.ReadLine();
                    continue;
                    
                }

                for (int i = 2; i < currentNumber; i++)
                {

                    int prime = currentNumber % i;

                    if (prime == 0 )
                    {
                        ifNonPrime = true;
                        break;
                    }
                }
                
                if (ifNonPrime)
                {
                    nonPrimeNumbersSum += currentNumber;
                }
                else 
                {
                    primeNumbersSum += currentNumber;
                }

                number = Console.ReadLine();
            }

            Console.WriteLine($"Sum of all prime numbers is: {primeNumbersSum}");
            Console.WriteLine($"Sum of all non prime numbers is: {nonPrimeNumbersSum}");

        }
    }
}
