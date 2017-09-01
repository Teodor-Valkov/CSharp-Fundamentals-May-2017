using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        IList<Person> people = new List<Person>();

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] inputArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string name = inputArgs[0];
            int age = int.Parse(inputArgs[1]);
            string address = inputArgs[2];

            Person person = new Person(name, age, address);
            people.Add(person);
        }

        int personIndex = int.Parse(Console.ReadLine());

        Person personNeeded = people[personIndex - 1];

        int matches = people.Count(person => person.CompareTo(personNeeded) == 0);

        Console.WriteLine(matches == 1
            ? "No matches"
            : $"{matches} {people.Count - matches} {people.Count}");
    }
}