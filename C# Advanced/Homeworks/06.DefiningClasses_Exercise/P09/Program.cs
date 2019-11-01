using System;
using System.Collections.Generic;
using System.Linq;

namespace P09
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            List<Trainer> trainers = new List<Trainer>();
            while ((input = Console.ReadLine()) != "Tournament")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string trainerName = tokens[0];
                string pokemonName = tokens[1];
                string pokemonElement = tokens[2];
                int pokemonHealth = int.Parse(tokens[3]);

                Trainer trainer = new Trainer(trainerName);
                if (!trainers.Any(x => x.Name == trainerName))
                {
                    trainers.Add(trainer);
                }
                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                trainer = trainers.First(x => x.Name == trainerName);

                trainer.Pokemons.Add(pokemon);

            }
            input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                foreach (var trainer in trainers)
                {
                    if (trainer.Pokemons.Any(x => x.PokemonElement == input))
                    {
                        trainer.NumberOfBadges++;
                    }
                    else
                    {
                        foreach (var pokemom in trainer.Pokemons)
                        {
                            pokemom.PokemonHealth -= 10;
                        }
                        trainer.Pokemons = trainer.Pokemons.Where(x => x.PokemonHealth > 0).ToList();
                    }
                }

            }
            foreach (var trainer in trainers.OrderByDescending(x => x.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemons.Count}");
            }
        }
    }
}
