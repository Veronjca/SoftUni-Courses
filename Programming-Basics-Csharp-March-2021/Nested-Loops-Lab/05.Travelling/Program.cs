using System;

namespace Travelling
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();


            while (destination != "End")
            {
                decimal budget = decimal.Parse(Console.ReadLine());

                decimal sum = 0;

                while (sum < budget)
                {

                    decimal money = decimal.Parse(Console.ReadLine());
                    sum += money;
                }

                
                Console.WriteLine($"Going to {destination}!");

                destination = Console.ReadLine();
            }


        }
    }
}
