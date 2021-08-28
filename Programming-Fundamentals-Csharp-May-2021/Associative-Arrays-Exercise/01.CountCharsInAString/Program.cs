using System;
using System.Collections.Generic;

namespace AssociativeArraysExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<char, int> countOfChars = new Dictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 32)
                {
                    continue;
                }

                if (countOfChars.ContainsKey(input[i]))
                {
                    countOfChars[input[i]]++;
                }
                else
                {
                    countOfChars.Add(input[i], 1);
                }
            }

            foreach (var @char in countOfChars)
            {
                Console.WriteLine($"{@char.Key} -> {@char.Value}");
            }
        }
    }
}
