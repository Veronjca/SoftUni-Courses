using System;

namespace PBExamMarch2019
{
    class Program
    {
        static void Main(string[] args)
        {
            double tax = double.Parse(Console.ReadLine());

            double shoes = tax - tax * 0.4;
            double outfit = shoes - shoes * 0.2;
            double ball = outfit * 1 / 4;
            double accessories = ball * 1 / 5;

            double total = shoes + outfit + ball + accessories + tax;

            Console.WriteLine($"{total:F2}");
        }
    }
}
