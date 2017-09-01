namespace _07.VladkoNotebook2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class StartUp
    {
        private class Player
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public List<string> Wins { get; set; }
            public List<string> Losses { get; set; }
        }

        private static void Main()
        {
            SortedDictionary<string, Player> dict = new SortedDictionary<string, Player>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputArgs = input.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                string color = inputArgs[0];

                if (!dict.ContainsKey(color))
                {
                    AddPlayer(inputArgs, color, dict);
                }
                else
                {
                    UpdatePlayer(inputArgs, color, dict);
                }
            }

            bool dataRecovered = PrintDataRecovered(dict, out dataRecovered);

            if (dataRecovered == false)
            {
                Console.WriteLine("No data recovered.");
            }
        }

        private static void AddPlayer(string[] inputArgs, string color, SortedDictionary<string, Player> dict)
        {
            Player player = new Player();

            switch (inputArgs[1])
            {
                case "age":
                    player.Age = int.Parse(inputArgs[2]);
                    break;

                case "name":
                    player.Name = inputArgs[2];
                    break;

                case "win":
                    List<string> wins = new List<string>();
                    wins.Add(inputArgs[2]);
                    player.Wins = wins;
                    break;

                case "loss":
                    List<string> losses = new List<string>();
                    losses.Add(inputArgs[2]);
                    player.Losses = losses;
                    break;
            }

            dict.Add(color, player);
        }

        private static void UpdatePlayer(string[] inputArgs, string color, SortedDictionary<string, Player> dict)
        {
            Player player = dict[color];

            switch (inputArgs[1])
            {
                case "age":
                    player.Age = int.Parse(inputArgs[2]);
                    dict[color] = player;
                    break;

                case "name":
                    player.Name = inputArgs[2];
                    dict[color] = player;
                    break;

                case "win":
                    List<string> wins = player.Wins ?? new List<string>();

                    wins.Add(inputArgs[2]);
                    player.Wins = wins;
                    dict[color] = player;
                    break;

                case "loss":
                    List<string> losses = player.Losses ?? new List<string>();

                    losses.Add(inputArgs[2]);
                    player.Losses = losses;
                    dict[color] = player;
                    break;
            }
        }

        private static bool PrintDataRecovered(SortedDictionary<string, Player> dict, out bool dataRecovered)
        {
            dataRecovered = false;

            foreach (KeyValuePair<string, Player> pair in dict)
            {
                List<string> wins = pair.Value.Wins;
                List<string> losses = pair.Value.Losses;

                if (pair.Value.Name != null && pair.Value.Age != 0)
                {
                    dataRecovered = true;

                    Console.WriteLine($"Color: {pair.Key}");
                    Console.WriteLine($"-age: {pair.Value.Age}");
                    Console.WriteLine($"-name: {pair.Value.Name}");

                    if (losses == null && wins == null)
                    {
                        Console.WriteLine("-opponents: (empty)");
                        Console.WriteLine("-rank: 1.00");
                    }
                    else if (losses != null && wins != null)
                    {
                        double rank = (wins.Count + 1.00) / (losses.Count + 1.00);
                        string[] oponents = pair.Value.Wins.Concat(pair.Value.Losses).ToArray();
                        PrintResult(oponents, rank);
                    }
                    else if (losses != null)
                    {
                        double rank = 1.00 / (losses.Count + 1.00);
                        string[] oponents = pair.Value.Losses.ToArray();
                        PrintResult(oponents, rank);
                    }
                    else if (wins != null)
                    {
                        double rank = (wins.Count + 1.00) / 1.00;
                        string[] oponents = pair.Value.Wins.ToArray();
                        PrintResult(oponents, rank);
                    }
                }
            }

            return dataRecovered;
        }

        private static void PrintResult(string[] oponents, double rank)
        {
            Array.Sort(oponents, StringComparer.Ordinal);

            Console.WriteLine($"-opponents: {string.Join(", ", oponents)}");
            Console.WriteLine($"-rank: {rank:F2}");
        }
    }
}