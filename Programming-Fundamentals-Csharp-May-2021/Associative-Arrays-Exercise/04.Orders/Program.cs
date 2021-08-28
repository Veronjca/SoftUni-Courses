using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary <string, List<double>> products = new Dictionary<string, List<double>>();


            while (input != "buy")
            {
                string[] inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (products.ContainsKey(inputArgs[0]))
                {
                    products[inputArgs[0]][0] = double.Parse(inputArgs[1]);
                    products[inputArgs[0]][1] += double.Parse(inputArgs[2]);
                }
                else
                {
                    products.Add(inputArgs[0], new List<double>());
                    products[inputArgs[0]].Add(double.Parse(inputArgs[1]));
                    products[inputArgs[0]].Add(double.Parse(inputArgs[2]));

                }
                input = Console.ReadLine();
            }

            foreach (var item in products)
            {
                Console.WriteLine($"{item.Key} -> {item.Value[0] * item.Value[1]:f2}");
            }
        }

       
    }
}
