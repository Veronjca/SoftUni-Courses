using System;

namespace _05.AddAndSubtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            int sum = Sum(firstNumber, secondNumber);
            int subtract = Subtract(sum, thirdNumber);
            Console.WriteLine(subtract);
        }

        private static int Subtract(int sum, int thirdNumber)
        {
            int subtract = sum - thirdNumber;
            return subtract;
        }

        private static int Sum(int firstNumber, int secondNumber)
        {
            int sum = firstNumber + secondNumber;
            return sum;
            
        }

       
    }
}
