using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        List<Animal> animals = new List<Animal>();

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "Beast!")
        {
            try
            {
                string[] inputArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string name = inputArgs[0];
                int age;

                if (!int.TryParse(inputArgs[1], out age))
                {
                    throw new ArgumentException("Invalid input!");
                }

                string gender = inputArgs[2];

                switch (input)
                {
                    case "Dog":
                        Dog dog = new Dog(name, age, gender);
                        animals.Add(dog);
                        break;

                    case "Frog":
                        Frog frog = new Frog(name, age, gender);
                        animals.Add(frog);
                        break;

                    case "Cat":
                        Cat cat = new Cat(name, age, gender);
                        animals.Add(cat);
                        break;

                    case "Kitten":
                        Kitten kitten = new Kitten(name, age);
                        animals.Add(kitten);
                        break;

                    case "Tomcat":
                        Tomcat tomcat = new Tomcat(name, age);
                        animals.Add(tomcat);
                        break;

                    default:
                        throw new ArgumentException("Invalid input!");
                }
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        foreach (Animal animal in animals)
        {
            Console.WriteLine(animal);
            animal.ProduceSound();
        }
    }
}