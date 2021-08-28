using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonDontGo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int sum = 0;

            while (input.Count > 0)
            {
                int index = int.Parse(Console.ReadLine());

                int value = 0;
             
                if (index < 0)
                {
                    value = input[0];
                    input.RemoveAt(0);
                    input.Insert(0, input[input.Count - 1]);
                }
                else if (index >= input.Count)
                {
                    value = input[input.Count - 1];
                    input.RemoveAt(input.Count - 1);
                    input.Add(input[0]);
                }
                else
                {
                   value = input[index];
                    input.RemoveAt(index);
                }

                

                for (int i = 0; i < input.Count; i++)
                {
                    if (input[i] > value)
                    {
                        input[i] = input[i] - value;
                    }
                    else
                    {
                        input[i] = input[i] + value;
                    }
                }

                sum += value;
            }

            
            Console.WriteLine(sum);
        }
    }
}
