using System;

namespace Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();

            int volume = width * length * height;
            int volumeLeft = volume;

            while (command != "Done")
            {
                int boxesQuantity = int.Parse(command);
                volumeLeft -= boxesQuantity;

                command = Console.ReadLine();

                if (volumeLeft < 0)
                {
                    Console.WriteLine($"No more free space! You need {Math.Abs(volumeLeft)} Cubic meters more.");
                    return;
                }
            }

            Console.WriteLine($"{volumeLeft} Cubic meters left.");
        }
    }
}
