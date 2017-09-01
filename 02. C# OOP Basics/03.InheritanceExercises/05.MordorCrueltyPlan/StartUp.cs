using System;

public class StartUp
{
    public static void Main()
    {
        string[] inputArgs = Console.ReadLine().ToLower().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        Gandalf gandalf = new Gandalf();
        FoodFactory foodFactory = new FoodFactory();
        MoodFactory moodFactory = new MoodFactory();

        foreach (string arg in inputArgs)
        {
            Food food = foodFactory.CreateFood(arg);
            gandalf.Eat(food);
        }

        Console.WriteLine(gandalf.GetHappinessPoints());
        Console.WriteLine(gandalf.GetMood(moodFactory));
    }
}