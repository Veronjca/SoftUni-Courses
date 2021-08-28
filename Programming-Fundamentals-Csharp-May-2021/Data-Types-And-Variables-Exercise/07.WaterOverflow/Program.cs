using System;

namespace _07.WaterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            byte n = byte.Parse(Console.ReadLine());

            ushort capacity = 255;
            ushort sum = 0;

            for (int i = 0; i < n; i++)
            {
                ushort liters = ushort.Parse(Console.ReadLine());

                sum += liters;
                if (capacity < liters)
                {
                    sum -= liters;
                    Console.WriteLine("Insufficient capacity!");
                }
                else
                {
                    capacity -= liters;
                }
                
            }

            Console.WriteLine(sum);
        }
    }
}
