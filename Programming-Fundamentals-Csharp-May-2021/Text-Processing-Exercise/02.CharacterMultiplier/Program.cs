using System;
using System.Linq;

namespace _02.CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .ToArray();

            int sum = 0;

            if (input[0].Length >= input[1].Length)
            {
                for (int i = 0; i < input[1].Length; i++)
                {
                    sum += input[0][i] * input[1][i];
                }

                for (int i = input[0].Length -1 ; i > input[1].Length-1; i--)
                {
                    sum += input[0][i];
                }
            }
            else
            {
                for (int i = 0; i < input[0].Length; i++)
                {
                    sum += input[0][i] * input[1][i];
                }

                for (int i = input[1].Length - 1; i > input[0].Length - 1; i--)
                {
                    sum += input[1][i];
                }
            }

            Console.WriteLine(sum);
        }
    }
}
