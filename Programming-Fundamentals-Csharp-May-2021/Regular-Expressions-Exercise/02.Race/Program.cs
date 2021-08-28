using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.Race
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> racers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Dictionary<string, int> allRacers = new Dictionary<string, int>();

            for (int i = 0; i < racers.Count; i++)
            {
                allRacers.Add(racers[i], 0);
            }

            string info = Console.ReadLine();

            string namePattern = @"[A-Za-z]";
            string distancePattern = @"\d";



            while (info != "end of race")
            {
                int distance = 0;

                string name = String.Join("", Regex.Matches(info, namePattern));
                MatchCollection allDigits = Regex.Matches(info, distancePattern);

                foreach (Match item in allDigits)
                {
                    distance += int.Parse(item.Value);
                }
                if (allRacers.ContainsKey(name))
                {
                    allRacers[name] += distance;
                }


                info = Console.ReadLine();
            }


            allRacers = allRacers.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine($"1st place: {allRacers.ElementAt(0).Key}");

            Console.WriteLine($"2nd place: {allRacers.ElementAt(1).Key}");

            Console.WriteLine($"3rd place: {allRacers.ElementAt(2).Key}");

        }
    }
}
