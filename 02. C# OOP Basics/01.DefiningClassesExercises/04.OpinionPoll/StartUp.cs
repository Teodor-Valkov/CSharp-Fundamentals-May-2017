using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        List<Person> people = new List<Person>();

        for (int i = 0; i < number; i++)
        {
            string[] inputArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string name = inputArgs[0];
            int age = int.Parse(inputArgs[1]);

            Person person = new Person(name, age);
            people.Add(person);
        }

        people = people
            .Where(person => person.Age > 30)
            .OrderBy(person => person.Name)
            .ToList();

        foreach (Person person in people)
        {
            Console.WriteLine($"{person.Name} - {person.Age}");
        }
    }
}