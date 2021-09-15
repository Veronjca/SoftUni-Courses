using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TheV_logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, HashSet<string>>> vLogger =
                new Dictionary<string, Dictionary<string, HashSet<string>>>();

            string input = Console.ReadLine();

            while (input != "Statistics")
            {
                string[] inputArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);


                if (inputArgs[1] == "joined" && !vLogger.ContainsKey(inputArgs[0]))
                {
                    vLogger.Add(inputArgs[0], new Dictionary<string, HashSet<string>>());

                    vLogger[inputArgs[0]].Add("following", new HashSet<string>());
                    vLogger[inputArgs[0]].Add("followers", new HashSet<string>());
                }
                else if (inputArgs[1] == "followed")
                {
                    if (vLogger.ContainsKey(inputArgs[0]) && vLogger.ContainsKey(inputArgs[2]) && inputArgs[0] != inputArgs[2])
                    {

                        vLogger[inputArgs[0]]["following"].Add(inputArgs[2]);
                        vLogger[inputArgs[2]]["followers"].Add(inputArgs[0]);
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"The V-Logger has a total of {vLogger.Count} vloggers in its logs.");

            vLogger = vLogger.OrderByDescending(x => x.Value["followers"].Count()).ThenBy(x => x.Value["following"].Count()).ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine($"1. {vLogger.First().Key} : {vLogger.First().Value["followers"].Count} followers, {vLogger.First().Value["following"].Count} following");

            foreach (var item in vLogger.First().Value["followers"].OrderBy(x => x))
            {
                Console.WriteLine($"* {item}");
            }

            int counter = 2;
          bool  isRemoved = vLogger.Remove(vLogger.First().Key);

            foreach (var item in vLogger)
            {
                Console.WriteLine($"{counter}. {item.Key} : {item.Value["followers"].Count} followers, {item.Value["following"].Count} following");
                counter++;
            }
        }
    }
}
