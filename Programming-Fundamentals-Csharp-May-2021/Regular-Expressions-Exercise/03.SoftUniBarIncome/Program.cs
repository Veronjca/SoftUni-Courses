using System;
using System.Text.RegularExpressions;

namespace _03.SoftUniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"%(?<name>[A-Z][a-z]+)%(?:[^|$\%\.0-9]+|)<(?<product>\w+)>(?:[^|$\%\.0-9]+|)\|(?<count>\d+)\|([^|$\%\.0-9]+|)(?<price>[0-9]+\.[0-9]+|[0-9]+)\$";

            double totalIncome = 0;

            while (input != "end of shift")
            {
                bool isMatch = Regex.IsMatch(input, pattern);

                if (isMatch)
                {
                    string customerName = Regex.Match(input, pattern).Groups["name"].Value;
                    string product = Regex.Match(input, pattern).Groups["product"].Value;
                    double totalPrice = int.Parse(Regex.Match(input, pattern).Groups["count"].Value) * double.Parse(Regex.Match(input, pattern).Groups["price"].Value);

                    Console.WriteLine($"{customerName}: {product} - {totalPrice:f2}");

                    totalIncome += totalPrice;
                }
                input = Console.ReadLine();
            }

            Console.WriteLine($"Total income: {totalIncome:f2}");
        }
    }
}
