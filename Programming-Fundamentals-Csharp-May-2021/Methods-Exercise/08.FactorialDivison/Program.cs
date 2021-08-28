using System;

namespace _08.FactorialDivison
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstNumber = double.Parse(Console.ReadLine());
            double secondNumber = double.Parse(Console.ReadLine());

            double firstNumberFactorial = FirstNumberFactorial(firstNumber);
            double secondNumberFactorial = SecondNumberFactorial(secondNumber);
            double factorialDivison = Division(firstNumberFactorial, secondNumberFactorial);

            Console.WriteLine($"{factorialDivison:f2}");
        }

        private static double Division(double firstNumberFactorial, double secondNumberFactorial)
        {
            double result = firstNumberFactorial / secondNumberFactorial;
            return result;

        }

        private static double SecondNumberFactorial(double secondNumber)
        {
            double result = 1;

            for (double i = secondNumber; i >= 2; i--)
            {
                result *= i;
            }
            return result;
        }

        private static double FirstNumberFactorial(double firstNumber)
        {
            double result = 1;

            for (double i = firstNumber; i >= 2; i--)
            {
                result *= i;
            }
            return result;
        }
    }
}
