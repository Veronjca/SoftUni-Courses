using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.CardsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstDeck = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> secondDeck = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToList();

            while (secondDeck.Count > 0 && firstDeck.Count > 0)
            {
                
                    if (firstDeck[0] > secondDeck[0])
                    {
                        firstDeck.Add(firstDeck[0]);
                        firstDeck.RemoveAt(0);
                        firstDeck.Add(secondDeck[0]);
                        secondDeck.Remove(secondDeck[0]);
                    }
                    else if (secondDeck[0] > firstDeck[0])
                    {
                        secondDeck.Add(secondDeck[0]);
                        secondDeck.RemoveAt(0);
                        secondDeck.Add(firstDeck[0]);
                        firstDeck.Remove(firstDeck[0]);
                    }
                    else if (secondDeck[0] == firstDeck[0])
                    {
                        secondDeck.Remove(secondDeck[0]);
                        firstDeck.Remove(firstDeck[0]);
                    }
                
            }



            if (firstDeck.Count > 0)
            {
                
                Console.WriteLine($"First player wins! Sum: {firstDeck.Sum()}");
            }
            else
            {
               
                Console.WriteLine($"Second player wins! Sum: {secondDeck.Sum()}");
            }
        }
    }
}
