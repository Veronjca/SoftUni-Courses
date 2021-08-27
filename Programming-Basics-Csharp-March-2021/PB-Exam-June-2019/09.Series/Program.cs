using System;

namespace Series
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double series = double.Parse(Console.ReadLine());

            double sum = 0;

            for (int i = 0; i < series; i++)
            {
                string name = Console.ReadLine();
                double price = double.Parse(Console.ReadLine());

                if (name == "Thrones")
                {
                    price /= 2;
                }
                else if (name == "Lucifer")
                {
                    price -= price * 0.4;
                }
                else if (name == "Protector")
                {
                    price -= price * 0.3;
                }
                else if (name == "TotalDrama")
                {
                    price -= price * 0.2;
                }
                else if (name == "Area")
                {
                    price -= price * 0.1;
                }

                sum += price;
            }

            if (budget >= sum)
            {
                Console.WriteLine($"You bought all the series and left with {budget - sum:f2} lv.");
            }
            else
            {
                Console.WriteLine($"You need {sum - budget:F2} lv. more to buy the series!");
            }
        }
    }
}
