using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<int[]> petrolPumps = new Queue<int[]>();

            for (int i = 0; i < n; i++)
            {
                int[] currentPump = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                petrolPumps.Enqueue(currentPump);
            }

            int counter = 0;

            while (true)
            {
                int totalPetrol = 0;

                foreach (var item in petrolPumps)
                {
                    int petrolAmount = item[0];
                    int distance = item[1];

                    totalPetrol += petrolAmount - distance;

                    if (totalPetrol < 0)
                    {
                        petrolPumps.Enqueue(petrolPumps.Dequeue());
                        counter++;
                        break;
                    }
                }

                if (totalPetrol >= 0)
                {
                    break;
                }
            }

            Console.WriteLine(counter);
        }
    }
}
