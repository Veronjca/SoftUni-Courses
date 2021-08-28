using System;

namespace _08.BeerKegs
{
    class Program
    {
        static void Main(string[] args)
        {
            byte lines = byte.Parse(Console.ReadLine());

            double maxVolume = double.MinValue;
            string keg = "";

            for (int i = 0; i < lines; i++)
            {
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                double volume = Math.PI * Math.Pow(radius, 2) * height;

                if (volume > maxVolume)
                {
                    maxVolume = volume;
                    keg = model;

                }
            }

            Console.WriteLine(keg);
            


        }
    }
}
