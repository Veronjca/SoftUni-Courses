using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.OddOccurances
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                .ToLower()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)               
                .ToList();

            Dictionary<string, int> odd = new Dictionary<string, int>();

            for (int i = 0; i < input.Count; i++)
            {
                string cuurentWord = input[i].ToLower();

               int occuranceCount =  input.Count(x => x == cuurentWord);

                if (occuranceCount % 2 != 0)
                {
                    odd.Add(cuurentWord, occuranceCount);
                }

                input.RemoveAll(x => x == cuurentWord);
                i = -1;
            }

           
           
            foreach (  var word in odd)
            {
                Console.Write($"{word.Key} ");
            }
        }
    }
}
