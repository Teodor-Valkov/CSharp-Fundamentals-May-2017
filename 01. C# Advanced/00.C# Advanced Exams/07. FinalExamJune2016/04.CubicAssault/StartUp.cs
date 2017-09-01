namespace _04.CubicAssault
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class StartUp
    {
        private static void Main()
        {
            Dictionary<string, Dictionary<string, long>> dict = new Dictionary<string, Dictionary<string, long>>();

            string input = string.Empty;
            while ((input = Console.ReadLine()).ToLower() != "count em all")
            {
                string[] inputArgs = input.Split(new[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                string region = inputArgs[0];
                string soldier = inputArgs[1];
                long count = long.Parse(inputArgs[2]);

                if (!dict.ContainsKey(region))
                {
                    dict[region] = new Dictionary<string, long>
                    {
                        ["Green"] = 0,
                        ["Red"] = 0,
                        ["Black"] = 0
                    };
                }

                dict[region][soldier] += count;

                while (dict[region]["Green"] >= 1000000)
                {
                    dict[region]["Green"] -= 1000000;
                    dict[region]["Red"]++;
                }

                while (dict[region]["Red"] >= 1000000)
                {
                    dict[region]["Red"] -= 1000000;
                    dict[region]["Black"]++;
                }
            }

            // Solution I
            //
            dict = dict
                .OrderByDescending(pair => pair.Value["Black"])
                .ThenBy(pair => pair.Key.Length)
                .ThenBy(pair => pair.Key)
                .ToDictionary(pair => pair.Key, pair => pair.Value);

            foreach (KeyValuePair<string, Dictionary<string, long>> pair in dict)
            {
                Console.WriteLine($"{pair.Key}");

                Dictionary<string, long> orderedPairValue = pair.Value
                    .OrderByDescending(innerPair => innerPair.Value)
                    .ThenBy(innerPair => innerPair.Key)
                    .ToDictionary(innerPair => innerPair.Key, innerPair => innerPair.Value);

                foreach (KeyValuePair<string, long> innerPair in orderedPairValue)
                {
                    Console.WriteLine($"-> {innerPair.Key} : {innerPair.Value}");
                }
            }

            // Solution II
            //
            dict
                .OrderByDescending(pair => pair.Value["Black"])
                .ThenBy(pair => pair.Key.Length)
                .ThenBy(pair => pair.Key)
                .ToList()
                .ForEach(pair =>
                {
                    Console.WriteLine($"{pair.Key}");
                    pair.Value
                     .OrderByDescending(innerPair => innerPair.Value)
                     .ThenBy(innerPair => innerPair.Key)
                     .ToList()
                     .ForEach(innerPair =>
                     {
                         Console.WriteLine($"-> {innerPair.Key} : {innerPair.Value}");
                     });
                });
        }
    }
}