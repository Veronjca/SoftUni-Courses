using System;

namespace _08.ThreeUple
{
    public class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 3; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (i == 0)
                {
                    string town = String.Empty;

                    try
                    {
                        town = $"{input[3]} {input[4]}";
                    }
                    catch (Exception)
                    {

                        town = input[3];
                    }
                    string name = $"{input[0]} {input[1]}";
                    string address = input[2];

                    var current = new Threeuple<string, string, string>(name, address, town);
                    Console.WriteLine(current);
                }
                else if (i == 1)
                {
                    string name = input[0];
                    string beerLiters = input[1];
                    bool drunk = input[2] == "drunk";
                    var current = new Threeuple<string, string, bool>(name, beerLiters, drunk);
                    Console.WriteLine(current);
                }
                else
                {
                    string name = input[0];
                    double bankBalance = double.Parse(input[1]);
                    string bankName = input[2];
                    var current = new Threeuple<string, double, string>(name, bankBalance, bankName);
                    Console.WriteLine(current);

                }
            }
        }
    }
}
