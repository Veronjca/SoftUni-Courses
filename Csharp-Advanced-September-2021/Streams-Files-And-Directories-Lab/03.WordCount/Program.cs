using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03.WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] wordsToSearch = File.ReadAllText("words.txt").Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] whereToSearch = File.ReadAllText("input.txt").Split(new char[] { '-', ' ', ',', '.', '?', '!' });
              
                
            
            Dictionary<string, int> matches = new Dictionary<string, int>();

           
            foreach (var item in wordsToSearch)
            {
                for (int i = 0; i < whereToSearch.Length; i++)
                {

                    if (item.ToLower() == whereToSearch[i].ToLower() && matches.ContainsKey(item))
                    {
                        matches[item]++;
                    }
                    else if (item.ToLower() == whereToSearch[i].ToLower())
                    {
                        matches.Add(item, 1);
                    }
                }

            }

            List<string> contents = new List<string>();
            foreach (var item in matches.OrderByDescending(x => x.Value))
            {
                contents.Add($"{item.Key}-{item.Value}");
            }

            File.WriteAllLines("output.txt", contents);
        }


    }
}
