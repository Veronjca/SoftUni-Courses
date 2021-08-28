using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            while (input != "end")
            {
                string[] courseInfo = input.Split(" : ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (courses.ContainsKey(courseInfo[0]))
                {
                    courses[courseInfo[0]].Add(courseInfo[1]);
                }
                else
                {
                    courses.Add(courseInfo[0], new List<string>());
                    courses[courseInfo[0]].Add(courseInfo[1]);
                }

                input = Console.ReadLine();
            }

            courses = courses.OrderByDescending(x => x.Value.Count).ToDictionary(x => x.Key, x => x.Value);

            

            foreach (var item in courses)
            {
                Console.WriteLine($"{item.Key}: {item.Value.Count}");

              List <string> sorted = item.Value.OrderBy(x => x).ToList();

                for (int i = 0; i < sorted.Count; i++)
                {
                    Console.WriteLine($"-- {sorted[i]}");
                }
            }

        }
    }
}
