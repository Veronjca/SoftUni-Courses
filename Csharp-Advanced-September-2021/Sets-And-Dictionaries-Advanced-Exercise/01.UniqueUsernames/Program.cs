using System;
using System.Collections.Generic;

namespace Sets_And_Dictionaries_Advanced_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            HashSet<string> usernames = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                usernames.Add(input);
            }

            foreach (var item in usernames)
            {
                Console.WriteLine(item);
            }
        }
    }
}
