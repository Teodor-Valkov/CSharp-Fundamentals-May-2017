namespace _07.VladkoNotebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    internal class StartUp
    {
        private static Dictionary<string, string> colorAndName = new Dictionary<string, string>();
        private static Dictionary<string, int> colorAndAge = new Dictionary<string, int>();
        private static Dictionary<string, List<string>> colorAndOpponents = new Dictionary<string, List<string>>();
        private static Dictionary<string, int> colorAndWins = new Dictionary<string, int>();
        private static Dictionary<string, int> colorAndLosses = new Dictionary<string, int>();

        private static void Main()
        {
            string patten = "^([A-Za-z\\s]+)\\|(name|age|win|loss)\\|(\\d+|[A-Za-z\\s]+)$";
            Regex regex = new Regex(patten);

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                Match match = regex.Match(input);

                UpdateDictionaries(match);
            }

            List<string> colors = new List<string>();

            List<string> firstColors = colorAndName.Keys.ToList();
            List<string> secondColors = colorAndAge.Keys.ToList();

            colors = firstColors.Intersect(secondColors).OrderBy(color => color).ToList();

            PrintResult(colors);
        }

        private static void UpdateDictionaries(Match match)
        {
            string color = match.Groups[1].Value;
            string action = match.Groups[2].Value;
            int age = 0;
            string name = string.Empty;
            string opponent = string.Empty;

            if (action == "name")
            {
                name = match.Groups[3].Value;
            }
            else if (action == "age")
            {
                age = int.Parse(match.Groups[3].Value);
            }
            else if (action == "win" || action == "loss")
            {
                opponent = match.Groups[3].Value;
            }

            if (action == "name")
            {
                colorAndName[color] = name;
            }
            else if (action == "age")
            {
                colorAndAge[color] = age;
            }
            else if (action == "win" || action == "loss")
            {
                if (!colorAndOpponents.ContainsKey(color))
                {
                    colorAndOpponents[color] = new List<string>();
                }

                if (!colorAndWins.ContainsKey(color) && !colorAndLosses.ContainsKey(color))
                {
                    colorAndWins[color] = 0;
                    colorAndLosses[color] = 0;
                }

                switch (action)
                {
                    case "win":
                        colorAndWins[color]++;
                        break;

                    case "loss":
                        colorAndLosses[color]++;
                        break;
                }

                colorAndOpponents[color].Add(opponent);
            }
        }

        private static void PrintResult(List<string> colors)
        {
            if (colors.Any())
            {
                foreach (string color in colors)
                {
                    if (!colorAndName.ContainsKey(color) || !colorAndAge.ContainsKey(color))
                    {
                        continue;
                    }

                    double rank = 1;

                    if (colorAndOpponents.ContainsKey(color))
                    {
                        rank = (colorAndWins[color] + 1.00) / (colorAndLosses[color] + 1.00);
                    }

                    if (colorAndOpponents.ContainsKey(color))
                    {
                        string[] opponents = colorAndOpponents[color].ToArray();
                        Array.Sort(opponents, StringComparer.Ordinal);

                        Console.WriteLine($"Color: {color}");
                        Console.WriteLine($"-age: {colorAndAge[color]}");
                        Console.WriteLine($"-name: {colorAndName[color]}");
                        Console.WriteLine(colorAndOpponents.ContainsKey(color)
                            ? $"-opponents: {string.Join(", ", opponents)}"
                            : "-opponents: (empty)");
                        Console.WriteLine($"-rank: {rank:F2}");
                    }
                }
            }
            else
            {
                Console.WriteLine("No data recovered.");
            }
        }
    }
}