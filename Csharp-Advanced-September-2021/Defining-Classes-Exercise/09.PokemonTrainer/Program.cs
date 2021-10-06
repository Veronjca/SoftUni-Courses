using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonTrainer
{
    public class Program
    {
        static void Main(string[] args)
        {
            string command;

            var trainers = new Dictionary<string, List<Pokemon>>();

            while ((command = Console.ReadLine()) != "Tournament")
            {
                string[] commandArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string trainerName = commandArgs[0];
                string pokemonName = commandArgs[1];
                string pokemonElement = commandArgs[2];
                int pokemonHealth = int.Parse(commandArgs[3]);

                Pokemon currentPokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                if (!trainers.ContainsKey(trainerName))
                {
                    trainers.Add(trainerName, new List<Pokemon>());
                }

                trainers[trainerName].Add(currentPokemon);
            }

            List<Trainer> trainers2 = new List<Trainer>();

            foreach (var trainer in trainers)
            {
                Trainer newTraniner = new Trainer(trainer.Key, trainer.Value);
                trainers2.Add(newTraniner);
            }

            while ((command = Console.ReadLine()) != "End")
            {
                
                foreach (var trainer in trainers2)
                {
                    bool flag = false;
                    foreach (var pokemon in trainer.Pokemons)
                    {
                        if (pokemon.Element == command)
                        {
                            flag = true;
                            break;
                        }
                    }

                    if (flag)
                    {
                        trainer.Badges++;
                    }
                    else
                    {
                        foreach (var pokemon in trainer.Pokemons)
                        {
                            pokemon.Health -= 10;

                        }
                       int removed = trainer.Pokemons.RemoveAll(x => x.Health <= 0);
                    }
                }
                       
            }

            trainers2.OrderByDescending(x => x.Badges).ToList().ForEach(x => Console.WriteLine($"{x.Name} {x.Badges} {x.Pokemons.Count}"));
        }
    }
}

