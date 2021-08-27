using System;

namespace AreaOfFigures
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeFigure = Console.ReadLine();

            if (typeFigure == "square")
            {
                double sideLength = double.Parse(Console.ReadLine());
                double areaSquare = sideLength * sideLength;
                Console.WriteLine($"{areaSquare:F3}");
            }
            else if (typeFigure == "rectangle")
            {
                double sideLength1 = double.Parse(Console.ReadLine());
                double sideLength2 = double.Parse(Console.ReadLine());
                double areaRectangle = sideLength1 * sideLength2;
                Console.WriteLine($"{areaRectangle:F3}");
            }
            else if (typeFigure == "circle")
            {
                double radius = double.Parse(Console.ReadLine());
                double areaCircle = Math.PI * (radius * radius);
                Console.WriteLine($"{areaCircle:F3}");
            }
            else if ( typeFigure == "triangle")
            {
                double sideLengthTriangle = double.Parse(Console.ReadLine());
                double sideHeight = double.Parse(Console.ReadLine());
                double areaTriangle = (sideLengthTriangle / 2) * sideHeight;
                Console.WriteLine($"{areaTriangle:F3}");
            }
        }
    }
}
