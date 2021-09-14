using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> wardrobe =
                new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string color = input[0];
                string[] clothes = input[1].Split(",", StringSplitOptions.RemoveEmptyEntries);

                if (wardrobe.ContainsKey(color))
                {
                    for (int j = 0; j < clothes.Length; j++)
                    {
                        if (wardrobe[color].ContainsKey(clothes[j]))
                        {
                            wardrobe[color][clothes[j]]++;
                        }
                        else
                        {
                            wardrobe[color].Add(clothes[j], 1);
                        }
                    }
                }
                else
                {
                    wardrobe.Add(color, new Dictionary<string, int>());

                    for (int k = 0; k < clothes.Length; k++)
                    {
                        wardrobe[color].Add(clothes[k], 1);
                    }
                }
            }

            string[] garmentToSearchFor = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in wardrobe)
            {
                Console.WriteLine($"{item.Key} clothes:");

           
                    foreach (var garment in item.Value)
                    {
                        if (garment.Key == garmentToSearchFor[1] && item.Key == garmentToSearchFor[0])
                        {
                            Console.WriteLine($"* {garment.Key} - {garment.Value} (found!)");
                        }
                        else
                        {
                            Console.WriteLine($"* {garment.Key} - {garment.Value}");
                        }
                    }
                
            }
             
            

        }
    }
}
