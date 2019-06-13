using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Tournament")
                {
                    break;
                }

                string[] inputArgs = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string trainerName = inputArgs[0];
                string pokemonName = inputArgs[1];
                string pokemonElement = inputArgs[2];
                int pokemonHealth = int.Parse(inputArgs[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                if (!trainers.Any(x=>x.Name == trainerName))
                {
                    trainers.Add(new Trainer(trainerName));

                }
                var trainer = trainers.First(t => t.Name == trainerName);
                trainer.Pokemons.Add(pokemon);

            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                foreach (Trainer trainer in trainers)
                {
                    if (trainer.Pokemons.Any(p => p.Element == input))
                    {
                        trainer.Badges++;
                    }
                    else
                    {
                        foreach (Pokemon pokemon in trainer.Pokemons)
                        {
                            pokemon.Health -= 10;
                        }
                        trainer.Pokemons = trainer.Pokemons.Where(p => p.Health > 0).ToList();
                    }
                }
            }

            foreach (var trainer in trainers.OrderByDescending(x => x.Badges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count}");
            }
        }
    }
}
