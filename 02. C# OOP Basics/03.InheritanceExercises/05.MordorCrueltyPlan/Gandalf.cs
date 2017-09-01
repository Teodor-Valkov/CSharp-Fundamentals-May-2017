using System.Collections.Generic;
using System.Linq;

public class Gandalf
{
    private List<Food> foodsEaten;
    private Mood mood;

    public Gandalf()
    {
        this.foodsEaten = new List<Food>();
    }

    public void Eat(Food food)
    {
        this.foodsEaten.Add(food);
    }

    public int GetHappinessPoints()
    {
        return this.foodsEaten.Sum(food => food.Points);
    }

    public Mood GetMood(MoodFactory moodFactory)
    {
        return moodFactory.CreateMood(this.GetHappinessPoints());
    }
}