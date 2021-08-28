using System;

namespace FootballSouvenirs
{
    class Program
    {
        static void Main(string[] args)
        {
            string team = Console.ReadLine();
            string souvenir = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());

            double price = 0;

            switch (team)
            {
                case "Argentina":
                    switch (souvenir)
                    {
                        case "flags":
                            price = 3.25;
                            break;
                        case "caps":
                            price = 7.20;
                            break;
                        case "posters":
                            price = 5.10;
                            break;
                        case "stickers":
                            price = 1.25;
                            break;
                        
                    }
                    break;
                case "Brazil":
                    switch (souvenir)
                    {
                        case "flags":
                            price = 4.20;
                            break;
                        case "caps":
                            price = 8.50;
                            break;
                        case "posters":
                            price = 5.35;
                            break;
                        case "stickers":
                            price = 1.20;
                            break;
                       
                    }
                    break;

                case "Croatia":
                    switch (souvenir)
                    {
                        case "flags":
                            price = 2.75;
                            break;
                        case "caps":
                            price = 6.90;
                            break;
                        case "posters":
                            price = 4.95;
                            break;
                        case "stickers":
                            price = 1.10;
                            break;
                        
                    }
                    break;

                case "Denmark":
                    switch (souvenir)
                    {
                        case "flags":
                            price = 3.10;
                            break;
                        case "caps":
                            price = 6.50;
                            break;
                        case "posters":
                            price = 4.80;
                            break;
                        case "stickers":
                            price = 0.90;
                            break;
                        
                    }
                    break;


            }

            double totalPrice = quantity * price;

            if (team != "Argentina" && team != "Brazil" && team != "Croatia" && team != "Denmark")
            {
                Console.WriteLine("Invalid country!");
            }
            else if (souvenir != "flags" && souvenir != "caps" && souvenir != "posters" && souvenir != "stickers")
            {
                Console.WriteLine("Invalid stock!");
            }
            else
            {
                Console.WriteLine($"Pepi bought {quantity} {souvenir} of {team} for {totalPrice:f2} lv.");
            }
        }
    }
}
