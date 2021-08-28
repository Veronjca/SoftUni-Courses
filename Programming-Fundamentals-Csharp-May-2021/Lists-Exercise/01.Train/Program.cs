using System;
using System.Collections.Generic;
using System.Linq;

namespace ListsExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int capacity = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (inputArgs[0] == "Add")
                {
                    wagons.Add(int.Parse(inputArgs[1]));
                }
                else
                {
                    int peopleToAdd = int.Parse(inputArgs[0]);

                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if (peopleToAdd + int.Parse(wagons[i].ToString()) <= capacity)
                        {
                            wagons[i] = peopleToAdd + int.Parse(wagons[i].ToString());
                            break;
                        }
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(String.Join(" ", wagons));


        }
    }
}
