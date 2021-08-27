using System;

namespace FishTank
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine());

            double volume = length * width * height;
            double liters = volume * 0.001;
            double percentage = percent * 0.01;

            double totalLiters = liters *(1- percentage);


            Console.WriteLine(totalLiters);
        }
    }
}
