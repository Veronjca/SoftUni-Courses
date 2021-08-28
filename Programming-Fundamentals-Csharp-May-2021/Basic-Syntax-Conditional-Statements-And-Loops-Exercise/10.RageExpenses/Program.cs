using System;

namespace _10.RageExpenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGamesCount = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displaytPrice = double.Parse(Console.ReadLine());

            double trashedHeadset = 0;
            double trashedMouse = 0;
            double trashedDisplays = 0;
            double trashedKeyboard = 0;

            for (int i = 1; i <= lostGamesCount; i++)
            {

                if (i % 2 == 0)
                {
                    trashedHeadset++;
                }   
            }

            for (int j = 1; j <= lostGamesCount; j++)
            {
                if (j % 3 == 0)
                {
                    trashedMouse++;
                }
            }

            for (int k = 1; k <= lostGamesCount; k++)
            {
                if (k % 6 == 0)
                {
                    trashedKeyboard++;
                }
            }

            for (int l = 1; l <= trashedKeyboard; l++)
            {
                if (l % 2 == 0)
                {
                    trashedDisplays++;
                }
              
            }

            double rageExpenses = (trashedHeadset * headsetPrice) + (trashedMouse * mousePrice) + (trashedKeyboard * keyboardPrice) + (trashedDisplays * displaytPrice);

            Console.WriteLine($"Rage expenses: {rageExpenses:f2} lv.");
        }
    }
}
