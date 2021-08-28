using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                .ToLower()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Dictionary<string, int> materials = new Dictionary<string, int>();
            materials.Add("motes", 0);
            materials.Add("fragments", 0);
            materials.Add("shards", 0);

            bool flag = false;

            while (true)
            {
                for (int i = 1; i < input.Count; i += 2)
                {
                    if (materials.ContainsKey(input[i]))
                    {

                        materials[input[i]] += int.Parse(input[i - 1]);
                    }
                    else
                    {

                        materials.Add(input[i], int.Parse(input[i - 1]));


                    }


                    foreach (var material in materials)
                    {
                        if (material.Key == "shards" && material.Value >= 250)
                        {
                            Console.WriteLine("Shadowmourne obtained!");
                            materials["shards"] -= 250;
                            flag = true;
                            break;


                        }
                        else if (material.Key == "fragments" && material.Value >= 250)
                        {
                            Console.WriteLine("Valanyr obtained!");
                            materials["fragments"] -= 250;
                            flag = true;
                            break;

                        }
                        else if (material.Key == "motes" && material.Value >= 250)
                        {
                            Console.WriteLine("Dragonwrath obtained!");
                            materials["motes"] -= 250;
                            flag = true;
                            break;

                        }
                    }

                    if (flag)
                    {
                        break;
                    }

                }

                if (flag)
                {
                    break;
                }

                input = Console.ReadLine()
                .ToLower()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            }

            Dictionary<string, int> junk = materials.Where(x => x.Key != "shards" && x.Key != "motes" && x.Key != "fragments").OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            materials = materials.Where(x => x.Key == "shards" || x.Key == "motes" || x.Key == "fragments").OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);




            foreach (var item in materials)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            foreach (var item in junk)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
