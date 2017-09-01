using System;

public class Topping
{
    private const double BaseCaloriesPerGram = 2;

    private string type;
    private int weight;

    public Topping(string type, int weight)
    {
        this.Type = type;
        this.Weight = weight;
    }

    public string Type
    {
        get
        {
            return this.type;
        }
        private set
        {
            if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }
            this.type = value;
        }
    }

    public int Weight
    {
        get
        {
            return this.weight;
        }
        private set
        {
            if (value < 1 || value > 50)
            {
                throw new ArgumentException($"{this.Type} weight should be in the range [1..50].");
            }
            this.weight = value;
        }
    }

    public double CalculateCalories()
    {
        double caloriesModifier = BaseCaloriesPerGram;

        switch (this.Type.ToLower())
        {
            case "meat": caloriesModifier *= 1.2; break;
            case "veggies": caloriesModifier *= 0.8; break;
            case "cheese": caloriesModifier *= 1.1; break;
            case "sauce": caloriesModifier *= 0.9; break;
        }

        return this.Weight * caloriesModifier;
    }
}