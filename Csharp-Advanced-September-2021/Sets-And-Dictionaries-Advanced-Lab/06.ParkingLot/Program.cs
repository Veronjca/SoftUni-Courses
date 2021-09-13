using System;
using System.Collections.Generic;

namespace _06.ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> parking = new HashSet<string>();

            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] commands = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);

                if (commands[0] == "IN")
                {
                    parking.Add(commands[1]);
                }
                else
                {
                    parking.Remove(commands[1]);
                }
            }

            if (parking.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }

            foreach (var item in parking)
            {
                Console.WriteLine(item);
            }
        }
    }
}
