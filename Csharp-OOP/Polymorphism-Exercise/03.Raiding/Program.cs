using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Raiding
{
   public  class Program
    {
        static void Main(string[] args)
        {
            int numberOfHeroes = int.Parse(Console.ReadLine());
            
            List<HeroFactory> heroes = new List<HeroFactory>();

            while (heroes.Count < numberOfHeroes)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();
                switch (heroType)
                {
                    case "Druid":
                        heroes.Add(new DruidFactory(heroName));
                        break;
                    case "Paladin":
                        heroes.Add(new PaladinFactory(heroName));
                        break;
                    case "Rogue":
                        heroes.Add(new RogueFactory(heroName));
                        break;
                    case "Warrior":
                        heroes.Add(new WarriorFactory(heroName));
                        break;
                    default:
                        Console.WriteLine("Invalid hero!");
                        break;

                }
            }

            int bossPower = int.Parse(Console.ReadLine());
            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.GetHero().CastAbility());
            }

            if (heroes.Sum(h => h.GetHero().Power) >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
