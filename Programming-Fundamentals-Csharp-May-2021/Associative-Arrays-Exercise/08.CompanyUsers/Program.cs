using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string,List< string>> companies = new Dictionary<string, List<string>>();

            while (input != "End")
            {

                string[] companiesInfo = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                List<string> values = new List<string>();

                companies.TryGetValue(companiesInfo[0], out values);
               
                if (companies.ContainsKey(companiesInfo[0]) && !values.Contains(companiesInfo[1]))
                {
                    companies[companiesInfo[0]].Add(companiesInfo[1]);
                }
                else if(!companies.ContainsKey(companiesInfo[0]))
                {
                    companies.Add(companiesInfo[0], new List<string>());
                    companies[companiesInfo[0]].Add(companiesInfo[1]);
                }

                input = Console.ReadLine();
            }

            companies = companies.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var company in companies)
            {
                Console.WriteLine($"{company.Key}");

                for (int i = 0; i < company.Value.Count; i++)
                {
                    Console.WriteLine($"-- {company.Value[i]}");
                }
            }
        }
    }
}
