using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PredicateParty
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Func<string, string, bool> endsWith = (x, y) => x.EndsWith(y);
            Func<string, string, bool> startsWith = (x, y) => x.StartsWith(y);
            Func<string, int, bool> length = (x, y) => x.Length == y;

            Func<List<string>, List<string>, List<string>> doubleThem = (first, second) =>
            {
                foreach(var item in second)
                {
                    for (int j = 0; j < first.Count; j++)
                    {
                        if (item == first[j])
                        {
                            first.Insert(j, item);
                            j++;
                            break;
                        }
                    }
                }

                return first;
            };

            string command;

            List<string> temp = new List<string>();

            while ((command = Console.ReadLine()) != "Party!")                
            {
                string[] commandArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (commandArgs[0] == "Remove")
                {
                    switch (commandArgs[1])
                    {
                        case "StartsWith":
                            people = people.Where(x => !startsWith(x, commandArgs[2])).ToList();
                            break;
                        case "EndsWith":
                            people = people.Where(x => !endsWith(x, commandArgs[2])).ToList();
                            break;
                        case "Length":
                            people = people.Where(x => !length(x, int.Parse(commandArgs[2]))).ToList();
                            break;
                        default:
                            break;
                    }
                }

                if (commandArgs[0] == "Double")
                {
                    switch (commandArgs[1])
                    {
                        case "StartsWith":
                            temp = people.Where(x => startsWith(x, commandArgs[2])).ToList();
                            people = doubleThem(people, temp);
                            break;
                        case "EndsWith":
                            temp = people.Where(x => endsWith(x, commandArgs[2])).ToList();
                            people = doubleThem(people, temp);
                            break;
                        case "Length":
                            temp = people.Where(x => length(x, int.Parse(commandArgs[2]))).ToList();
                            
                           people = doubleThem(people, temp);
                            break;
                        default:
                            break;
                    }
                }
            }

            Console.WriteLine(people.Any() ? $"{String.Join(", ", people)} are going to the party!" : "Nobody is going to the party!");
        }
    }
}
