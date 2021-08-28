using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RegularExpressionsExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^>>(?<name>[A-Za-z]+)<<(?<price>\d+(?:\.\d+|))!(?<quantity>\d+\b)";

            string input = Console.ReadLine();

            List<string> furniture = new List<string>();

            double price = 0;

            while (input != "Purchase")
            {
                bool isMatch = Regex.IsMatch(input, pattern);

                if (isMatch)
                {
                    furniture.Add(Regex.Match(input, pattern).Groups["name"].Value);
                    price += double.Parse(Regex.Match(input, pattern).Groups["price"].Value) * double.Parse(Regex.Match(input, pattern).Groups["quantity"].Value);
                }
                input = Console.ReadLine();
            }

            Console.WriteLine($"Bought furniture:");

            foreach (var item in furniture)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"Total money spend: {price:f2}");

        }
    }
}
