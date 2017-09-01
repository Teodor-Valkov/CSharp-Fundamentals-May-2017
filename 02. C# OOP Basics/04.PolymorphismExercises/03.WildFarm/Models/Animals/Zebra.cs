using System;

public class Zebra : Mammal
{
    public Zebra(string animalName, string animalType, double animalWeight, string llivingRegion)
        : base(animalName, animalType, animalWeight, llivingRegion)
    {
    }

    public override void Eat(Food food)
    {
        if (food.GetType().Name != "Vegetable")
        {
            throw new ArgumentException($"{this.GetType().Name}s are not eating that type of food!");
        }

        base.Eat(food);
    }

    public override string MakeSound()
    {
        return "Zs";
    }
}