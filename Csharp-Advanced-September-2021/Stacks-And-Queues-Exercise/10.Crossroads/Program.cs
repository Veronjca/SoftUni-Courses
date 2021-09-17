using System;
using System.Collections.Generic;

namespace _10.Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            Queue<string> cars = new Queue<string>();

            int counter = 0;

            int temp = greenLightDuration;

            while (input != "END")
            {
                if (input == "green")
                {
                    while (cars.Count > 0 && temp > 0)
                    {
                        if (cars.Peek().Length > temp)
                        {
                            string leftover = cars.Peek().Substring(temp);

                            if (leftover.Length > freeWindow)
                            {
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{cars.Dequeue()} was hit at {leftover[freeWindow]}.");

                                return;
                            }
                            else
                            {
                                counter++;
                                cars.Dequeue();
                                break;
                            }

                        }
                        else
                        {
                            counter++;
                            temp -= cars.Dequeue().Length;
                        }


                    }
                }
                else
                {
                    cars.Enqueue(input);
                }

                temp = greenLightDuration;

                input = Console.ReadLine();
            }


            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{counter} total cars passed the crossroads.");

        }
    }
}
