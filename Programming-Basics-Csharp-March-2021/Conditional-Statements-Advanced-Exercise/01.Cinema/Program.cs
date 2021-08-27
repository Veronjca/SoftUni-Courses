using System;

namespace ConditionalStatementsAdvancedExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            string projectionType = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int columns = int.Parse(Console.ReadLine());

            double hallArea = rows * columns;
            double income = 0;

            switch (projectionType)
            {
                case "Premiere":
                    income = hallArea * 12;
                    break;
                case "Normal":
                    income = hallArea * 7.50;
                    break;
                case "Discount":
                    income = hallArea * 5;
                    break;
            }
            Console.WriteLine($"{income:F2} leva");
        }
    }
}
