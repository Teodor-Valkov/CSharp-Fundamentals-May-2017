using _03.WildFarm.Factories;
using System;

public class StartUp
{
    public static void Main()
    {
        string input = string.Empty;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] animalArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] foodArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Animal animal = AnimalFactory.CreateAnimal(animalArgs);
            Food food = FoodFactory.CreateFood(foodArgs);

            Console.WriteLine(animal.MakeSound());

            try
            {
                animal.Eat(food);
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }

            Console.WriteLine(animal);
        }
    }
}