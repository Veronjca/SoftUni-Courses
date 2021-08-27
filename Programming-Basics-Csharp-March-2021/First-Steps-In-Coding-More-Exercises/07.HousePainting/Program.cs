using System;

namespace HousePainting
{
    class Program
    {
        static void Main(string[] args)
        {
            // височина на къщата
            double x = double.Parse(Console.ReadLine());
            // дължина на страничната стена
            double y = double.Parse(Console.ReadLine());
            // височината на триъгълната стена на прокрива 
            double h = double.Parse(Console.ReadLine());

            //стени на къщата
            double frontWallArea = (x * x) - 2.4;
            double backWallArea = x * x;
            double leftWallArea = (x * y) - 2.25;
            double rightWallArea = (x * y) - 2.25;

            // покрив на къщата
            double lefttWallRoof = x * y;
            double rightdWallRoof = x * y;
            double frontWallRoof = (x * h) / 2;
            double backWallRoof = (x * h) / 2;

            // разход на зелена боя
            double greenPaint = (frontWallArea + backWallArea + leftWallArea + rightWallArea) / 3.4;

            // разход на червена боя
            double redPaint = (lefttWallRoof + rightdWallRoof + frontWallRoof + backWallRoof) / 4.3;

            Console.WriteLine($"{greenPaint:F2}");
            Console.WriteLine($"{redPaint:F2}");










        }
    }
}
