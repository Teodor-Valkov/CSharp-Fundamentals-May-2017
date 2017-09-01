using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        List<Team> teams = new List<Team>();

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] inputArgs = input.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            string action = inputArgs[0];

            switch (action)
            {
                case "Team":
                    AddTeam(teams, inputArgs);
                    break;

                case "Add":
                    AddPlayerToTeam(teams, inputArgs);
                    break;

                case "Remove":
                    RemovePlayerFromTeam(teams, inputArgs);
                    break;

                case "Rating":
                    CalculateTeamRating(teams, inputArgs);
                    break;
            }
        }
    }

    private static void AddTeam(List<Team> teams, string[] inputArgs)
    {
        string teamName = inputArgs[1];

        // Add the team if it passes the property validations
        try
        {
            Team team = new Team(teamName);
            teams.Add(team);
        }
        catch (ArgumentException exception)
        {
            Console.WriteLine(exception.Message);
        }
    }

    private static void AddPlayerToTeam(List<Team> teams, string[] inputArgs)
    {
        string teamName = inputArgs[1];
        string playerName = inputArgs[2];
        int endurance = int.Parse(inputArgs[3]);
        int sprint = int.Parse(inputArgs[4]);
        int dribble = int.Parse(inputArgs[5]);
        int passing = int.Parse(inputArgs[6]);
        int shooting = int.Parse(inputArgs[7]);

        Team team = teams.FirstOrDefault(t => t.Name == teamName);

        // Return to main logic if the team does not exist
        if (team == null)
        {
            Console.WriteLine($"Team {teamName} does not exist.");
            return;
        }

        // Add the player if he passes the property vaidations
        try
        {
            Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
            team.AddPlayer(player);
        }
        catch (ArgumentException exception)
        {
            Console.WriteLine(exception.Message);
        }
    }

    private static void RemovePlayerFromTeam(List<Team> teams, string[] inputArgs)
    {
        string teamName = inputArgs[1];
        string playerName = inputArgs[2];

        Team team = teams.FirstOrDefault(t => t.Name == teamName);

        // Return to main logic if the team does not exist
        if (team == null)
        {
            Console.WriteLine($"Team {teamName} does not exist.");
            return;
        }

        // Remove the player if he exists in the team
        try
        {
            team.RemovePlayer(playerName);
        }
        catch (ArgumentException exception)
        {
            Console.WriteLine(exception.Message);
        }
    }

    private static void CalculateTeamRating(List<Team> teams, string[] inputArgs)
    {
        string teamName = inputArgs[1];
        Team team = teams.FirstOrDefault(t => t.Name == teamName);

        // Print the team rating if the team exists
        Console.WriteLine(team == null
            ? $"Team {teamName} does not exist."
            : $"{team.Name} - {team.GetTeamRating()}");
    }
}