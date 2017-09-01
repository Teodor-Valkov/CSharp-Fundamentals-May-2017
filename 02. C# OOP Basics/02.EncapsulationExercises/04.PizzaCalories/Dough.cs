using System;

public class Dough
{
    private const double BaseCaloriesPerGram = 2;

    private string flourType;
    private string bakingTechnique;
    private int weight;

    public Dough(string flourType, string bakingTechnique, int weight)
    {
        this.FlourType = flourType;
        this.BakingTechnique = bakingTechnique;
        this.Weight = weight;
    }

    public string FlourType
    {
        get
        {
            return this.flourType;
        }
        private set
        {
            if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            this.flourType = value;
        }
    }

    public string BakingTechnique
    {
        get
        {
            return this.bakingTechnique;
        }
        private set
        {
            if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            this.bakingTechnique = value;
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
            if (value < 1 || value > 200)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }
            this.weight = value;
        }
    }

    public double CalculateCalories()
    {
        double caloriesModifier = BaseCaloriesPerGram;

        switch (this.FlourType.ToLower())
        {
            case "white": caloriesModifier *= 1.5; break;
            case "wholegrain": caloriesModifier *= 1.0; break;
        }

        switch (this.BakingTechnique.ToLower())
        {
            case "crispy": caloriesModifier *= 0.9; break;
            case "chewy": caloriesModifier *= 1.1; break;
            case "homemade": caloriesModifier *= 1.0; break;
        }

        return this.Weight * caloriesModifier;
    }
}