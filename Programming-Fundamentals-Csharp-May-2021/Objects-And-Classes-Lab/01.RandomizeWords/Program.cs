using System;
using System.Collections.Generic;
using System.Linq;

namespace ObjectsAndClassesLab
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .ToList();

            var rnd = new Random();

            

            for (int i = 0; i < words.Count; i++)
            {
                int temp = rnd.Next(0, words.Count-1);
                
                words.Add(words[temp]);
                words.Remove(words[temp]);
                

            }


            for (int i = 0; i < words.Count; i++)
            {
                Console.WriteLine(words[i]);
            }
        }
    }
}
