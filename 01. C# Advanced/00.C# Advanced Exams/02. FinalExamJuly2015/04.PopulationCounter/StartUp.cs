namespace _04.PopulationCounter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class StartUp
    {
        private static void Main()
        {
            Dictionary<string, Dictionary<string, long>> dict = new Dictionary<string, Dictionary<string, long>>();

            string input = String.Empty;
            while ((input = Console.ReadLine()).ToLower() != "report")
            {
                string[] inputArgs = input.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                string city = inputArgs[0];
                string country = inputArgs[1];
                long population = long.Parse(inputArgs[2]);

                if (!dict.ContainsKey(country))
                {
                    dict.Add(country, new Dictionary<string, long>());
                }

                dict[country][city] = population;
            }

            foreach (KeyValuePair<string, Dictionary<string, long>> pair in dict.OrderByDescending(pair => pair.Value.Values.Sum()))
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