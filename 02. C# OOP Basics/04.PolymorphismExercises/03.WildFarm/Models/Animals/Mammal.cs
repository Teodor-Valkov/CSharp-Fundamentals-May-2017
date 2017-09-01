public abstract class Mammal : Animal
{
    private string livingRegion;

    protected Mammal(string animalName, string animalType, double animalWeight, string llivingRegion)
        : base(animalName, animalType, animalWeight)
    {
        this.livingRegion = llivingRegion;
    }

    protected string LivingRegion
    {
        get
        {
            return this.livingRegion;
        }
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}[{this.AnimalName}, {this.AnimalWeight}, {this.livingRegion}, {this.FoodEaten}]";
    }
}