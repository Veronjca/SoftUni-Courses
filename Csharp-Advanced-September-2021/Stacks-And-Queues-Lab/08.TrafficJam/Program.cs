using System;
using System.Collections.Generic;

namespace _08.TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            // number of cars that can pass during green light
            int n = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();
            string input = Console.ReadLine();

            int counter = 0;

            while (input != "end")
            {
                if (input == "green")
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (cars.Count > 0)
                        {
                            string car = cars.Dequeue();

                            Console.WriteLine($"{car} passed!");
                            counter++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }


                input = Console.ReadLine();
            }

            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}
