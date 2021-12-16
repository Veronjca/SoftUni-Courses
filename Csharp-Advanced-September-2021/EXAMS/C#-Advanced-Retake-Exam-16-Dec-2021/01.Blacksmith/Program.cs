using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Blacksith
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> entities = new Dictionary<string, int>()
            {
                { "Gladius", 0 },
                {"Shamshir", 0 },
                {"Katana", 0 },
                {"Sabre", 0 },
                {"Broadsword",0 }
            };
            Queue<int> steel = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> carbon = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            while (carbon.Count > 0 && steel.Count > 0)
            {
                int currentSteel = steel.Dequeue();
                int currentCarbon = carbon.Pop();
                int sum = currentCarbon + currentSteel;

                if (sum == 70)
                {
                    entities["Gladius"]++;
                }
                else if (sum == 80)
                {
                    entities["Shamshir"]++;
                }
                else if (sum == 90)
                {
                    entities["Katana"]++;
                }
                else if (sum == 110)
                {
                    entities["Sabre"]++;
                }
                else if (sum == 150)
                {
                    entities["Broadsword"]++;
                }
                else
                {
                    currentCarbon += 5;
                    carbon.Push(currentCarbon);
                }
            }

            Console.WriteLine(entities.Sum(e => e.Value) > 0 ? $"You have forged {entities.Sum(e => e.Value)} swords." : "You did not have enough resources to forge a sword.");
            Console.WriteLine(steel.Count > 0 ? $"Steel left: {string.Join(", ", steel)}" : "Steel left: none");
            Console.WriteLine(carbon.Count > 0 ? $"Carbon left: {string.Join(", ", carbon)}" : "Carbon left: none");

            entities = entities.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in entities.Where(e => e.Value > 0).OrderBy(e => e.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
