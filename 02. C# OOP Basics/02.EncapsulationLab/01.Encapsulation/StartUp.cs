using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        List<Person> persons = new List<Person>();

        for (int i = 0; i < number; i++)
        {
            string[] inputArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string firstName = inputArgs[0];
            string lastName = inputArgs[1];
            int age = int.Parse(inputArgs[2]);
            double salary = double.Parse(inputArgs[3]);

            Person person = new Person(firstName, lastName, age, salary);
            persons.Add(person);
        }

        Team team = new Team("Team");

        persons.ForEach(person => team.AddPlayer(person));

        Console.WriteLine($"First team have {team.FirstTeam.Count} players");
        Console.WriteLine($"Reserve team have {team.ReserveTeam.Count} players");
    }
}