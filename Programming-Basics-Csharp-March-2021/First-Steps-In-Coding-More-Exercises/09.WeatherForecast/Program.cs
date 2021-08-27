using System;

namespace WeatherForecast
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();


            if (text == "sunny") 
            {
                Console.WriteLine("It's warm outside!");
            }

            else
            {
                Console.WriteLine("It's cold outside!");
            }
        }
    }
}
