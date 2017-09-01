using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        ISet<Person> sortedSetNames = new SortedSet<Person>(new PersonNameComparer());
        ISet<Person> sortedSetAges = new SortedSet<Person>(new PersonAgeComparer());

        int number = int.Parse(Console.ReadLine());

        for (int i = 0; i < number; i++)
        {
            string[] inputArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string name = inputArgs[0];
            int age = int.Parse(inputArgs[1]);

            Person person = new Person(name, age);
            sortedSetNames.Add(person);
            sortedSetAges.Add(person);
        }

        PrintPeople(sortedSetNames);
        PrintPeople(sortedSetAges);
    }

    private static void PrintPeople(ISet<Person> sortedSetPeople)
    {
        foreach (Person person in sortedSetPeople)
        {
            Console.WriteLine(person);
        }
    }
}