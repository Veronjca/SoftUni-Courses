using System;
using System.Collections.Generic;

namespace _03.ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> shops = new SortedDictionary<string, Dictionary<string, double>>();

            string command;

            while ((command = Console.ReadLine()) != "Revision")
            {
                string[] commandArgs = command
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string shop = commandArgs[0];
                string product = commandArgs[1];
                double price = double.Parse(commandArgs[2]);

                if (shops.ContainsKey(shop))
                {
                    shops[shop].Add(product, price);
                }
                else
                {
                    shops.Add(shop, new Dictionary<string, double>());
                    shops[shop].Add(product, price);
                }
            }

            foreach (var item in shops)
            {
                Console.WriteLine($"{item.Key}->");
                foreach (var product in item.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
