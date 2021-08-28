using System;

namespace _06.CalculateRectangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            int area = CalculateRectangleArea(width, height);

            Console.WriteLine(area);
        }

        private static int CalculateRectangleArea(int width, int height)
        {
            int area = width * height;

            return area;
        }
    }
}
