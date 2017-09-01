namespace _04.OlympicsAreComing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    internal class StartUp
    {
        private static void Main()
        {
            Dictionary<string, Dictionary<string, int>> dict = new Dictionary<string, Dictionary<string, int>>();

            string input = String.Empty;
            while ((input = Console.ReadLine()).ToLower() != "report")
            {
                string[] inputArgs = input.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                string name = inputArgs[0].Trim();
                name = Regex.Replace(name, "\\s+", " ");

                string country = inputArgs[1].Trim();
                country = Regex.Replace(country, "\\s+", " ");

                if (!dict.ContainsKey(country))
                {
                    dict[country] = new Dictionary<string, int>();
                }

                if (!dict[country].ContainsKey(name))
                {
                    dict[country][name] = 0;
                }

                dict[country][name]++;
            }

            dict
                .OrderByDescending(pair => pair.Value.Values.Sum())
                .ToList()
                .ForEach(pair =>
                    Console.WriteLine($"{pair.Key} ({pair.Value.Keys.Count} participants): {pair.Value.Values.Sum()} wins"));
        }
    }
}