using System;

namespace Renovation
{
    class Program
    {
        static void Main(string[] args)
        {
            double height = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double notPaintedArea = double.Parse(Console.ReadLine());

            double percentage = notPaintedArea / 100;

            double area = 4 * (height * width);
            double totalArea = Math.Ceiling(area - (area * percentage));

            string paint = Console.ReadLine();

            while (paint != "Tired!")
            {
                double paintLiters = double.Parse(paint);

                totalArea -= paintLiters;

                if (totalArea < 0 )
                {
                    Console.WriteLine($"All walls are painted and you have {Math.Abs(totalArea)} l paint left!");
                    return;
                }
                else if (totalArea == 0)
                {
                    Console.WriteLine("All walls are painted! Great job, Pesho!");
                    return;
                }

                paint = Console.ReadLine();
            }

            Console.WriteLine($"{totalArea} quadratic m left.");
        }
    }
}
