using System;

namespace _03.WildFarm.Factories
{
    public class AnimalFactory
    {
        public static Animal CreateAnimal(string[] animalArgs)
        {
            var animalType = animalArgs[0];
            var animalName = animalArgs[1];
            var animalWeight = double.Parse(animalArgs[2]);
            var livingRegion = animalArgs[3];

            switch (animalType)
            {
                case "Mouse":
                    return new Mouse(animalName, animalType, animalWeight, livingRegion);

                case "Zebra":
                    return new Zebra(animalName, animalType, animalWeight, livingRegion);

                case "Cat":
                    string breed = animalArgs[4];
                    return new Cat(animalName, animalType, animalWeight, livingRegion, breed);

                case "Tiger":
                    return new Tiger(animalName, animalType, animalWeight, livingRegion);

                default:
                    throw new ArgumentException();
            }
        }
    }
}