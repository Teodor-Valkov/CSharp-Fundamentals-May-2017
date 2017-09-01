namespace _04.ChampionsLeague
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Team
    {
        public Team(string name)
        {
            this.Name = name;
            this.Opponents = new List<string>();
        }

        public string Name { get; set; }
        public int Wins { get; set; }
        public List<string> Opponents { get; set; }
    }

    internal class StartUp
    {
        private static void Main()
        {
            List<Team> teams = new List<Team>();

            string input = string.Empty;
            while ((input = Console.ReadLine()).ToLower() != "stop")
            {
                string pattern = @"([a-zA-Z\s]+)\s\|\s([a-zA-Z\s]+)\s\|\s(\d+:\d+)\s\|\s(\d+:\d+)";
                Regex regex = new Regex(pattern);

                Match match = regex.Match(input);

                Team firstTeam = new Team(match.Groups[1].Value);
                Team secondTeam = new Team(match.Groups[2].Value);
                string firstScore = match.Groups[3].Value;
                string secondScore = match.Groups[4].Value;

                int firstTeamGoals = int.Parse(firstScore.Split(':')[0]) + int.Parse(secondScore.Split(':')[1]);
                int secondTeamGoals = int.Parse(firstScore.Split(':')[1]) + int.Parse(secondScore.Split(':')[0]);

                bool firstTeamIsWinner;

                if (firstTeamGoals > secondTeamGoals)
                {
                    firstTeamIsWinner = true;
                }
                else if (firstTeamGoals < secondTeamGoals)
                {
                    firstTeamIsWinner = false;
                }
                else
                {
                    int firstTeamAwayGoals = int.Parse(secondScore.Split(':')[1]);
                    int secondTeamAwayGoals = int.Parse(firstScore.Split(':')[1]);

                    firstTeamIsWinner = firstTeamAwayGoals > secondTeamAwayGoals;
                }

                if (firstTeamIsWinner)
                {
                    UpdateWinner(teams, firstTeam, secondTeam);
                    UpdateLoser(teams, secondTeam, firstTeam);
                }
                else
                {
                    UpdateWinner(teams, secondTeam, firstTeam);
                    UpdateLoser(teams, firstTeam, secondTeam);
                }
            }

            teams = teams
                .OrderByDescending(team => team.Wins)
                .ThenBy(team => team.Name)
                .ToList();

            foreach (Team team in teams)
            {
                Console.WriteLine($"{team.Name}");
                Console.WriteLine($"- Wins: {team.Wins}");
                Console.WriteLine($"- Opponents: {string.Join(", ", team.Opponents.OrderBy(t => t))}");
            }
        }

        private static void UpdateWinner(List<Team> teams, Team firstTeam, Team secondTeam)
        {
            if (teams.All(t => t.Name != firstTeam.Name))
            {
                firstTeam.Wins++;
                firstTeam.Opponents.Add(secondTeam.Name);
                teams.Add(firstTeam);
            }
            else
            {
                Team existingTeam = teams.First(t => t.Name == firstTeam.Name);
                teams.Remove(existingTeam);

                existingTeam.Wins++;
                existingTeam.Opponents.Add(secondTeam.Name);
                teams.Add(existingTeam);
            }
        }

        private static void UpdateLoser(List<Team> teams, Team secondTeam, Team firstTeam)
        {
            if (teams.All(t => t.Name != secondTeam.Name))
            {
                secondTeam.Opponents.Add(firstTeam.Name);
                teams.Add(secondTeam);
            }
            else
            {
                Team existingTeam = teams.First(t => t.Name == secondTeam.Name);
                teams.Remove(existingTeam);

                existingTeam.Opponents.Add(firstTeam.Name);
                teams.Add(existingTeam);
            }
        }
    }
}