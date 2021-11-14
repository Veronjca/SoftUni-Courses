using System;

namespace PCGameShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int hearthstone = 0;
            int fornite = 0;
            int overwatch = 0;
            int others = 0;

            for (int i = 0; i < number; i++)
            {
                string name = Console.ReadLine();

                if (name == "Hearthstone")
                {
                    hearthstone++;
                }
                else if (name == "Fornite")
                {
                    fornite++;
                }
                else if (name == "Overwatch")
                {
                    overwatch++;
                }
                else
                {
                    others++;
                }


            }

            double hearthstonePercentage = ((double)hearthstone / (double)number) * 100;
            double fornitePercentage = ((double)fornite / (double)number) * 100;
            double overwatchPercentage = ((double)overwatch / (double)number) * 100;
            double othersPercentage = ((double)others / (double)number) * 100;

            Console.WriteLine($"Hearthstone - {hearthstonePercentage:f2}%");
            Console.WriteLine($"Fornite - {fornitePercentage:F2}%");
            Console.WriteLine($"Overwatch - {overwatchPercentage:f2}%");
            Console.WriteLine($"Others - {othersPercentage:f2}%");
        }
    }
}
