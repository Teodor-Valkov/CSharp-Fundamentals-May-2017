using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        List<Person> people = new List<Person>();

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] inputArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string personName = inputArgs[0];
            string inputType = inputArgs[1];

            if (people.All(person => person.Name != personName))
            {
                Person person = new Person(personName);
                people.Add(person);
            }

            switch (inputType)
            {
                case "company":
                    string name = inputArgs[2];
                    string department = inputArgs[3];
                    decimal salary = decimal.Parse(inputArgs[4]);

                    Company company = new Company(name, department, salary);
                    people.First(person => person.Name == personName).Company = company;
                    break;

                case "car":
                    string model = inputArgs[2];
                    int speed = int.Parse(inputArgs[3]);

                    Car car = new Car(model, speed);
                    people.First(person => person.Name == personName).Car = car;
                    break;

                case "pokemon":
                    string pokemonName = inputArgs[2];
                    string type = inputArgs[3];

                    Pokemon pokemon = new Pokemon(pokemonName, type);
                    people.First(person => person.Name == personName).Pokemons.Add(pokemon);
                    break;

                case "parents":
                    string parentName = inputArgs[2];
                    string parentBirthday = inputArgs[3];

                    Parent parent = new Parent(parentName, parentBirthday);
                    people.First(person => person.Name == personName).Parents.Add(parent);
                    break;

                case "children":
                    string childrenName = inputArgs[2];
                    string childBirthday = inputArgs[3];

                    Child child = new Child(childrenName, childBirthday);
                    people.First(person => person.Name == personName).Children.Add(child);
                    break;
            }
        }

        string personNeeded = Console.ReadLine();
        Console.WriteLine(people.First(person => person.Name == personNeeded));
    }
}