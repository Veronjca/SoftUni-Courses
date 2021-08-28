using System;

namespace DataTypesAndVariablesExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());
            int fourthNumber = int.Parse(Console.ReadLine());

            int sum = firstNumber + secondNumber;

            int division = sum / thirdNumber;

            int result = division * fourthNumber;

            Console.WriteLine(result);
        }
    }
}
