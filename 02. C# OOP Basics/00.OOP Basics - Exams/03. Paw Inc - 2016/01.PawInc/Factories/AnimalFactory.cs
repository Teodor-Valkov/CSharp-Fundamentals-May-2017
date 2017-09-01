namespace _01.PawInc.Factories
{
    using Models;
    using Models.Animals;
    using System;

    public class AnmalFactory
    {
        public static Animal CreateAnimal(string type, string name, int age, int commandsOrIntelligence, string centerName)
        {
            switch (type)
            {
                case "Dog":
                    return new Dog(name, age, commandsOrIntelligence, centerName);

                case "Cat":
                    return new Cat(name, age, commandsOrIntelligence, centerName);

                default:
                    throw new ArgumentException("Invalid animal!");
            }
        }
    }
}