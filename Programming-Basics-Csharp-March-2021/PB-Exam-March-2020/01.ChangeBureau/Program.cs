using System;

namespace PBExamMarch2020
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal bitcoins = decimal.Parse(Console.ReadLine());
            decimal chinaYuan = decimal.Parse(Console.ReadLine());
            decimal comission = decimal.Parse(Console.ReadLine());

            decimal bitcoinsToLeva = bitcoins * 1168;
            decimal yuansToDollars = chinaYuan * (decimal)0.15;
            decimal dollarsToLeva = yuansToDollars * (decimal)1.76;

            decimal euro = (bitcoinsToLeva + dollarsToLeva) / (decimal)1.95;
            decimal totalComission = (comission / 100);
            decimal totalEuro = euro - (euro * totalComission);

            Console.WriteLine($"{totalEuro:f2}");
        }
    }
}
