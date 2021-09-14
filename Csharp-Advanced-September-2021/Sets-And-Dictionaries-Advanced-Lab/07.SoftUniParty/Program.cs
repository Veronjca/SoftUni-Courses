using System;
using System.Collections.Generic;

namespace _07.SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vip = new HashSet<string>();
            HashSet<string> regular = new HashSet<string>();

            string input;

            while ((input = Console.ReadLine()) != "PARTY")
            {
                if (char.IsDigit(input[0]))
                {
                    vip.Add(input);
                }
                else
                {
                    regular.Add(input);
                }
            }

            while ((input = Console.ReadLine()) != "END")
            {
                if (char.IsDigit(input[0]))
                {
                    if (vip.Contains(input))
                    {
                        vip.Remove(input);
                    }
                }
                else
                {
                    if (regular.Contains(input))
                    {
                        regular.Remove(input);
                    }
                }
            }

            Console.WriteLine($"{vip.Count + regular.Count}");

            foreach (var item in vip)
            {
                Console.WriteLine(item);
            }

            foreach (var item in regular)
            {
                Console.WriteLine(item);
            }
        }
    }
}
