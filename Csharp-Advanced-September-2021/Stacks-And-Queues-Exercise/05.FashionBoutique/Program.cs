using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rackCapacity = int.Parse(Console.ReadLine());

            Stack<int> clothes = new Stack<int>(input.Reverse());

            int sum = 0;
            int counter = 1;

            while (clothes.Count > 0)
            {
                sum += clothes.Peek();

                if (sum <= rackCapacity)
                {
                    if (sum == rackCapacity)
                    {
                        clothes.Pop();
                        sum = 0;
                        if (clothes.Count > 0)
                        {
                            counter++;
                        }
                        
                    }
                    else
                    {
                        clothes.Pop();
                    }
                }
                else
                {
                    sum = 0;
                    counter++;
                }

            }


            Console.WriteLine(counter);
        }
    }
}
