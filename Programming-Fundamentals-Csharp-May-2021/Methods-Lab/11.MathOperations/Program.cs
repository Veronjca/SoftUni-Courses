using System;

namespace _11.MathOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int firsNumber = int.Parse(Console.ReadLine());
            string @operator = Console.ReadLine();
            int secondNumber = int.Parse(Console.ReadLine());

            int result = GetResult(firsNumber, @operator, secondNumber);

            Console.WriteLine($"{result}");


        }

        private static int GetResult(int firsNumber, string operation, int secondNumber)
        {
            int result = 0;

            if (operation == "/")
            {
                result = firsNumber / secondNumber;
            }
            else if (operation == "*")
            {
                result = firsNumber * secondNumber;
            }
            else if (operation == "+")
            {
                result = firsNumber + secondNumber;
            }
            else if (operation == "-")
            {
                result = firsNumber - secondNumber;
            }

            return result;
        }
    }
}
