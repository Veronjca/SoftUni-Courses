using System;

namespace _06.ForeignLanguages
{
    class Program
    {
        static void Main(string[] args)
        {
            string countryName = Console.ReadLine();

            switch (countryName)
            {

                case "USA":
                case "England":
                    Console.WriteLine("English");
                    break;
                case "Spain":
                case "Argentina":
                case "Mexico":
                    Console.WriteLine("Spanish");
                    break;
                default:
                    Console.WriteLine("unknown");
                    break;
            }
        }
    }
}
