public class Cat : Felime
{
    private string breed;

    public Cat(string animalName, string animalType, double animalWeight, string llivingRegion, string breed)
        : base(animalName, animalType, animalWeight, llivingRegion)
    {
        this.breed = breed;
    }

    public override string MakeSound()
    {
        return "Meowwww";
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}[{this.AnimalName}, {this.breed}, {this.AnimalWeight}, {this.LivingRegion}, {this.FoodEaten}]";
    }
}