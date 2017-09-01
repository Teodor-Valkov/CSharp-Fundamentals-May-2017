using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        List<Trainer> trainers = new List<Trainer>();

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "Tournament")
        {
            string[] inputArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string trainerName = inputArgs[0];
            string pokemonName = inputArgs[1];
            string element = inputArgs[2];
            int health = int.Parse(inputArgs[3]);

            Pokemon pokemon = new Pokemon(pokemonName, element, health);
            Trainer trainer = trainers.FirstOrDefault(tr => tr.Name == trainerName);

            if (trainer == null)
            {
                trainer = new Trainer(trainerName);
                trainer.Pokemons.Add(pokemon);
                trainers.Add(trainer);
            }
            else
            {
                trainer.Pokemons.Add(pokemon);
            }
        }

        string neededElement = string.Empty;
        while ((neededElement = Console.ReadLine()) != "End")
        {
            switch (neededElement)
            {
                case "Fire":
                    trainers
                      .Where(trainer => trainer.Pokemons.Any(pokemon => pokemon.Element == neededElement))
                      .ToList()
                      .ForEach(trainer => trainer.IncreaseBadges());

                    trainers
                        .Where(trainer => trainer.Pokemons.All(pokemon => pokemon.Element != neededElement))
                        .ToList()
                        .ForEach(trainer => trainer.Pokemons.ForEach(pokemon => pokemon.DecreaseHealth()));
                    break;

                case "Water":
                    trainers
                        .Where(trainer => trainer.Pokemons.Any(pokemon => pokemon.Element == neededElement))
                        .ToList()
                        .ForEach(trainer => trainer.IncreaseBadges());

                    trainers
                        .Where(trainer => trainer.Pokemons.All(pokemon => pokemon.Element != neededElement))
                        .ToList()
                        .ForEach(trainer => trainer.Pokemons.ForEach(pokemon => pokemon.DecreaseHealth()));
                    break;

                case "Electricity":
                    trainers
                        .Where(trainer => trainer.Pokemons.Any(pokemon => pokemon.Element == neededElement))
                        .ToList()
                        .ForEach(trainer => trainer.IncreaseBadges());

                    trainers
                        .Where(trainer => trainer.Pokemons.All(pokemon => pokemon.Element != neededElement))
                        .ToList()
                        .ForEach(trainer => trainer.Pokemons.ForEach(pokemon => pokemon.DecreaseHealth()));
                    break;
            }

            trainers.ForEach(trainer => trainer.Pokemons.RemoveAll(pokemon => pokemon.Health <= 0));
        }

        foreach (Trainer trainer in trainers.OrderByDescending(tr => tr.Badges))
        {
            Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count}");
        }
    }
}