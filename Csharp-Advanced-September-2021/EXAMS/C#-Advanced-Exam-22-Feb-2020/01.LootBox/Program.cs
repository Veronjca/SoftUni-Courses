using System;
using System.Collections.Generic;
using System.Linq;

namespace LootBox
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> firstBox = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Stack<int> secondBox = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            List<int> claimed = new List<int>();

            while (true)
            {
                if (firstBox.Count == 0)
                {
                    Console.WriteLine("First lootbox is empty");
                    break;
                }
                else if (secondBox.Count == 0)
                {
                    Console.WriteLine("Second lootbox is empty");
                    break;
                }

                int sum = firstBox.Peek() + secondBox.Peek();
                if (sum % 2 == 0)
                {
                    claimed.Add(sum);
                    firstBox.Dequeue();
                    secondBox.Pop();
                }
                else
                {
                    firstBox.Enqueue(secondBox.Pop());
                }
            }

            Console.WriteLine(claimed.Sum() >= 100 ? $"Your loot was epic! Value: {claimed.Sum()}" : $"Your loot was poor... Value: {claimed.Sum()}");
        }
    }
}
