namespace _04.ChampionsLeague2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class StartUp
    {
        private static Dictionary<string, int> teamAndWins = new Dictionary<string, int>();
        private static Dictionary<string, SortedSet<string>> teamAndOpponents = new Dictionary<string, SortedSet<string>>();

        private static void Main()
        {
            string input = string.Empty;
            while ((input = Console.ReadLine()).ToLower() != "stop")
            {
                string[] inputArgs = input.Split(new[] { " | " }, StringSplitOptions.RemoveEmptyEntries);
                string firstTeam = inputArgs[0];
                string secondTeam = inputArgs[1];
                string firstScore = inputArgs[2];
                string secondScore = inputArgs[3];

                string winningTeam = FindWinner(firstTeam, secondTeam, firstScore, secondScore);

                AddTeamAndWins(firstTeam, firstTeam == winningTeam);
                AddTeamAndWins(secondTeam, secondTeam == winningTeam);

                AddOpponents(firstTeam, secondTeam);
                AddOpponents(secondTeam, firstTeam);
            }

            foreach (KeyValuePair<string, int> pair in teamAndWins.OrderByDescending(pair => pair.Value).ThenBy(pair => pair.Key))
            {
                Console.WriteLine($"{pair.Key}");
                Console.WriteLine($"- Wins: {pair.Value}");
                Console.WriteLine($"- Opponents: {string.Join(", ", teamAndOpponents[pair.Key])}");
            }
        }

        private static string FindWinner(string firstTeam, string secondTeam, string firstScore, string secondScore)
        {
            int firstTeamGoals = int.Parse(firstScore.Split(':')[0]) + int.Parse(secondScore.Split(':')[1]);
            int secondTeamGoals = int.Parse(firstScore.Split(':')[1]) + int.Parse(secondScore.Split(':')[0]);

            if (firstTeamGoals == secondTeamGoals)
            {
                int firstTeamAwayGoals = int.Parse(secondScore.Split(':')[1]);
                int secondTeamAwayGoals = int.Parse(firstScore.Split(':')[1]);

                return firstTeamAwayGoals > secondTeamAwayGoals ? firstTeam : secondTeam;
            }

            return firstTeamGoals > secondTeamGoals ? firstTeam : secondTeam;
        }

        private static void AddTeamAndWins(string team, bool isWinner)
        {
            if (!teamAndWins.ContainsKey(team))
            {
                teamAndWins[team] = 0;
            }

            if (isWinner)
            {
                teamAndWins[team]++;
            }
        }

        private static void AddOpponents(string team, string opponent)
        {
            if (!teamAndOpponents.ContainsKey(team))
            {
                teamAndOpponents[team] = new SortedSet<string>();
            }

            teamAndOpponents[team].Add(opponent);
        }
    }
}