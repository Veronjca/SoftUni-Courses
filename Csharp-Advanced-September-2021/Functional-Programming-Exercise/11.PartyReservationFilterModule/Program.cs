using System;
using System.Collections.Generic;
using System.Linq;

namespace Functional_Programming
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            var filters = new Dictionary<string, Predicate<string>>();

            string input;

            while ((input = Console.ReadLine()) != "Print")
            {
                string[] inputArgs = input.Split(';', StringSplitOptions.RemoveEmptyEntries);
                string command = inputArgs[0];
                string filterType = inputArgs[1];
                string argument = inputArgs[2];

                if (command == "Add filter")
                {
                    if (!filters.ContainsKey($"{filterType}-{argument}"))
                    {
                       
                        filters.Add($"{filterType}-{argument}", GetPredicate(filterType, argument));
                    }
                }
                else if (command == "Remove filter")
                {
                    filters.Remove($"{filterType}-{argument}");
                }
            }

            foreach (var item in filters)
            {
                people.RemoveAll(item.Value);
            }

            Console.WriteLine(String.Join(" ", people));
        }

        private static Predicate<string> GetPredicate(string filterType, string argument)
        {

            if (filterType == "Starts with")
            {
                return name => name.StartsWith(argument);
            }
            else if (filterType == "Ends with")
            {
                return name => name.EndsWith(argument);
            }
            else if (filterType == "Length")
            {
                return name => name.Length == int.Parse(argument);
            }
            else if (filterType == "Contains")
            {
                return name => name.Contains(argument);
            }

            throw new ArgumentException("Invalid command!");
        }
    }
}
