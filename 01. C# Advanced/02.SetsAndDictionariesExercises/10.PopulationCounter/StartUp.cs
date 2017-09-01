namespace _10.PopulationCounter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class StartUp
    {
        private static void Main()
        {
            Dictionary<string, Dictionary<string, long>> countryCityPopulation = new Dictionary<string, Dictionary<string, long>>();

            string input = string.Empty;
            while ((input = Console.ReadLine()).ToLower() != "report")
            {
                string[] inputArgs = input.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                string city = inputArgs[0];
                string country = inputArgs[1];
                long population = long.Parse(inputArgs[2]);

                if (!countryCityPopulation.ContainsKey(country))
                {
                    countryCityPopulation.Add(country, new Dictionary<string, long>());
                }

                countryCityPopulation[country][city] = population;
            }

            countryCityPopulation = countryCityPopulation
                .OrderByDescending(pair => pair.Value.Values.Sum())
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (KeyValuePair<string, Dictionary<string, long>> pair in countryCityPopulation)
            {
                Console.WriteLine($"{pair.Key} (total population: {pair.Value.Values.Sum()})");

                foreach (KeyValuePair<string, long> innerPair in pair.Value.OrderByDescending(innerPair => innerPair.Value))
                {
                    Console.WriteLine($"=>{innerPair.Key}: {innerPair.Value}");
                }
            }
        }
    }
}