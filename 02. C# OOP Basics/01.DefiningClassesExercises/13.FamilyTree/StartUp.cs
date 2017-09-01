using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Startup
{
    public static void Main()
    {
        string nameOrBirthday = Console.ReadLine();

        // People as objects
        List<Person> people = new List<Person>();

        // People as strings
        List<string> peopleAsStrings = new List<string>();

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] inputArgs = input.Split(new[] { " - " }, StringSplitOptions.RemoveEmptyEntries);

            if (inputArgs.Length == 1)
            {
                int lastIndexOfSpace = input.LastIndexOf(' ');

                string name = input.Substring(0, lastIndexOfSpace);
                string birthday = input.Substring(lastIndexOfSpace + 1);

                Person person = new Person(name, birthday);
                people.Add(person);
            }
            else
            {
                peopleAsStrings.Add(input);
            }
        }

        foreach (string personAsString in peopleAsStrings)
        {
            Person parent = null;
            Person child = null;

            string[] inputArgs = personAsString.Split(new[] { " - " }, StringSplitOptions.RemoveEmptyEntries);

            // Input arguments are dates of birthday
            if (inputArgs[0].Contains('/') && inputArgs[1].Contains('/'))
            {
                string parentBirhtday = inputArgs[0];
                string childrenBirthday = inputArgs[1];

                // Find the people with these birthdays
                parent = people.First(p => p.Birthday == parentBirhtday);
                child = people.First(p => p.Birthday == childrenBirthday);
            }
            // One of the input argument is birthday
            else if (inputArgs[0].Contains('/') || inputArgs[1].Contains('/'))
            {
                string name = string.Empty;
                string birthday = string.Empty;

                // First input argument is birthday
                if (inputArgs[0].Contains('/'))
                {
                    birthday = inputArgs[0];
                    name = inputArgs[1];

                    parent = people.First(p => p.Birthday == birthday);
                    child = people.First(p => p.Name == name);
                }
                // Second input argument is birthday
                else if (inputArgs[1].Contains('/'))
                {
                    birthday = inputArgs[1];
                    name = inputArgs[0];

                    child = people.First(p => p.Birthday == birthday);
                    parent = people.First(p => p.Name == name);
                }
            }
            // Both input arguments are names
            else
            {
                string parentName = inputArgs[0];
                string childrenName = inputArgs[1];

                parent = people.First(p => p.Name == parentName);
                child = people.First(p => p.Name == childrenName);
            }

            if (!parent.Children.Contains(child))
            {
                parent.Children.Add(child);
            }

            if (!child.Parents.Contains(parent))
            {
                child.Parents.Add(parent);
            }
        }

        // Find the needed person
        Person neededPerson = nameOrBirthday.Contains('/')
            ? people.First(p => p.Birthday == nameOrBirthday)
            : people.First(p => p.Name == nameOrBirthday);

        StringBuilder sb = new StringBuilder();

        sb.AppendLine(neededPerson.ToString());

        sb.AppendLine("Parents:");
        foreach (Person parent in neededPerson.Parents)
        {
            sb.AppendLine(parent.ToString());
        }

        sb.AppendLine("Children:");
        foreach (Person child in neededPerson.Children)
        {
            sb.AppendLine(child.ToString());
        }

        Console.Write(sb);
    }
}