using System;

namespace _03.FloatingEquality
{
    class Program
    {
        static void Main(string[] args)
        {
            double number1 = double.Parse(Console.ReadLine());
            double number2 = double.Parse(Console.ReadLine());

            bool greaterNum = Math.Abs(number1 - number2) <= 0.000001;

            Console.WriteLine(greaterNum);
        }
    }
}
