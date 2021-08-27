using System;

namespace VetParking
{
    class Program
    {
        static void Main(string[] args)
        {
            double days = double.Parse(Console.ReadLine());
            double hours = double.Parse(Console.ReadLine());

            double totalSum = 0;
            for (int i = 1; i <= days; i++)
            {
                double sum = 0;

                for (int j = 1; j <= hours; j++)
                {
                    if (i % 2 != 0 && j % 2 == 0)
                    {
                        sum += 1.25;
                    }
                    else if (i % 2 == 0 && j % 2 != 0)
                    {
                        sum += 2.50;
                    }
                    else
                    {
                        sum += 1;
                    }
                }

                Console.WriteLine($"Day: {i} - {sum:f2} leva");

                totalSum += sum;
            }

            Console.WriteLine($"Total: {totalSum:F2} leva");
        }
    }
}
