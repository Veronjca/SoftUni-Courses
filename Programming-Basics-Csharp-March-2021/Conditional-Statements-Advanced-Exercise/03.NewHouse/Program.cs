using System;

namespace NewHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            string flowerType = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            double rosesPrice = quantity * 5;
            double dahliasPrice = quantity * 3.80;
            double tulipsPrice = quantity * 2.80;
            double narcissusPrice = quantity * 3;
            double gladiolusPrice = quantity * 2.50;

            double totalPrice = 0;

            switch (flowerType)
            {
                case "Roses":
                    if (quantity > 80)
                    {
                        totalPrice = rosesPrice - (rosesPrice * 0.1);
                    }
                    else
                    {
                        totalPrice = rosesPrice;
                    }
                    break;
                case "Dahlias":
                    if (quantity > 90)
                    {
                        totalPrice = dahliasPrice - (dahliasPrice * 0.15);
                    }
                    else
                    {
                        totalPrice = dahliasPrice;
                    }
                    break;
                case "Tulips":
                    if (quantity > 80)
                    {
                        totalPrice = tulipsPrice - (tulipsPrice * 0.15);
                    }
                    else
                    {
                        totalPrice = tulipsPrice;
                    }
                    break;
                case "Narcissus":
                    if (quantity < 120)
                    {
                        totalPrice = narcissusPrice + (narcissusPrice * 0.15);
                    }
                    else
                    {
                        totalPrice = narcissusPrice;
                    }
                    break;
                case "Gladiolus":
                    if (quantity < 80)
                    {
                        totalPrice = gladiolusPrice + (gladiolusPrice * 0.2);
                    }
                    else
                    {
                        totalPrice = gladiolusPrice;
                    }
                    break;      
            }
            
            if ( totalPrice > budget)
            {
                Console.WriteLine($"Not enough money, you need {(totalPrice - budget):F2} leva more.");
            }
            else
            {
                Console.WriteLine($"Hey, you have a great garden with {quantity} {flowerType} and {(budget - totalPrice):F2} leva left.");
            }
        }
    }
}
