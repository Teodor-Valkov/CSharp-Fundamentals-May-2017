namespace _04.AshesOfRoses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    internal class StartUp
    {
        private static void Main()
        {
            Dictionary<string, Dictionary<string, long>> regions = new Dictionary<string, Dictionary<string, long>>();

            string pattern = "^Grow\\s<([A-Z][a-z]+)>\\s<([A-Za-z0-9]+)>\\s(\\d+)$";
            Regex regex = new Regex(pattern);

            string input = string.Empty;
            while ((input = Console.ReadLine()).ToLower() != "icarus, ignite!")
            {
                Match match = regex.Match(input);

                if (!match.Success)
                {
                    continue;
                }

                string region = match.Groups[1].Value;
                string color = match.Groups[2].Value;
                int amount = int.Parse(match.Groups[3].Value);

                if (!regions.ContainsKey(region))
                {
                    regions[region] = new Dictionary<string, long>();
                }

                if (!regions[region].ContainsKey(color))
                {
                    regions[region][color] = 0;
                }

                regions[region][color] += amount;
            }

            regions = regions
                .OrderByDescending(pair => pair.Value.Values.Sum())
                .ThenBy(pair => pair.Key)
                .ToDictionary(pair => pair.Key, pair => pair.Value);

            foreach (KeyValuePair<string, Dictionary<string, long>> region in regions)
            {
                Console.WriteLine($"{region.Key}");

                Dictionary<string, long> roses = region.Value
                    .OrderBy(rose => rose.Value)
                    .ThenBy(rose => rose.Key)
                    .ToDictionary(rose => rose.Key, rose => rose.Value);

                foreach (KeyValuePair<string, long> innerPair in roses)
                {
                    Console.WriteLine($"*--{innerPair.Key} | {innerPair.Value}");
                }
            }
        }
    }
}