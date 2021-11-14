using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01.TheFightForGondor
{
    class Program
    {
        static void Main(string[] args)
        {
            int waves = int.Parse(Console.ReadLine());
            Queue<int> plates = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> wariors = new Stack<int>();

            for (int i = 1; i <= waves; i++)
            {
                wariors = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
                if (plates.Count <= 0)
                {
                    break;
                }
                if (i % 3 == 0)
                {
                    plates.Enqueue(int.Parse(Console.ReadLine()));
                }

                while (wariors.Count > 0)
                {
                    int currentWarior = wariors.Pop();
                    int currentPlate = plates.Dequeue();
                    if (currentWarior > currentPlate)
                    {
                        currentWarior -= currentPlate;
                        wariors.Push(currentWarior);
                    }
                    else if (currentWarior < currentPlate)
                    {
                        plates = new Queue<int>(plates.Prepend(currentPlate - currentWarior));
                    }
                    if (plates.Count <= 0)
                    {
                        Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                        Console.WriteLine(String.Join(", ", wariors));
                        return;
                    }
                }

            }
            if (wariors.Count <= 0)
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine(String.Join(", ", plates));
            }
            else
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine(String.Join(", ", wariors));
            }
     
        }
    }
}
