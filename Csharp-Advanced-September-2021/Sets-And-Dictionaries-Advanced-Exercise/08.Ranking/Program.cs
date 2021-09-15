using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();

            string input;

            while ((input = Console.ReadLine()) != "end of contests")
            {
                string[] contestInput = input.Split(':', StringSplitOptions.RemoveEmptyEntries);
                string contest = contestInput[0];
                string password = contestInput[1];

                if (!contests.ContainsKey(contest))
                {
                    contests.Add(contest, password);
                }
            }

            Dictionary<string, Dictionary<string, int>> candidates = new Dictionary<string, Dictionary<string, int>>();

            while ((input = Console.ReadLine()) != "end of submissions")
            {
                string[] submissionInput = input.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string contest = submissionInput[0];
                string password = submissionInput[1];
                string username = submissionInput[2];
                int points = int.Parse(submissionInput[3]);

                string value = String.Empty;

                if (contests.TryGetValue(contest, out value))
                {
                    if (value == password)
                    {
                        if (!candidates.ContainsKey(username))
                        {
                            candidates.Add(username, new Dictionary<string, int>());
                            candidates[username].Add(contest, points);
                        }
                        else
                        {
                            int oldPoints = 0;

                            if (candidates[username].ContainsKey(contest))
                            {
                                oldPoints = candidates[username].GetValueOrDefault(contest);

                                if (oldPoints < points)
                                {
                                    candidates[username][contest] = points;
                                }
                            }
                            else
                            {
                                candidates[username].Add(contest, points);
                            }
                        }
                    }
                }

            }

            string bestCandidate = String.Empty;
            int bestPoints = 0;

            foreach (var item in candidates)
            {
                int sum = 0;

                foreach (var contest in item.Value)
                {
                    sum += contest.Value;
                }

                if (sum > bestPoints)
                {
                    bestCandidate = item.Key;
                    bestPoints = sum;
                }
            }

            Console.WriteLine($"Best candidate is {bestCandidate} with total {bestPoints} points.");
            Console.WriteLine($"Ranking:");

            candidates = candidates.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in candidates)
            {
                Console.WriteLine(item.Key);
                foreach (var contest in item.Value.OrderByDescending(x=>x.Value))
                {
                    Console.WriteLine($"# {contest.Key}->{contest.Value}");
                }
            }
        }
    }
}
