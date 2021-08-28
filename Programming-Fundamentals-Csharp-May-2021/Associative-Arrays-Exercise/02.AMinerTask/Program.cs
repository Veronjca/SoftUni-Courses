using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.AMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string resource = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());

            Dictionary<string, List <int>> mine = new Dictionary<string, List <int>>();

            while (resource != "stop")
            {
                
                if (mine.ContainsKey(resource))
                {
                    mine[resource].Add(quantity);
                }
                else
                {
                    mine.Add(resource, new List<int>());
                    mine[resource].Add(quantity);
                }


                resource = Console.ReadLine();

                if (resource == "stop")
                {
                    continue;
                }
                quantity = int.Parse(Console.ReadLine());
            }

            foreach (var item in mine)
            {
                Console.WriteLine($"{item.Key} -> {item.Value.Sum()}");
            }
        }
    }
}
