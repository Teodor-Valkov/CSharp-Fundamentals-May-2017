public abstract class Animal
{
    private string animalName;
    private string animalType;
    private double animalWeight;
    private int foodEaten;

    protected Animal(string animalName, string animalType, double animalWeight)
    {
        this.animalName = animalName;
        this.animalType = animalType;
        this.animalWeight = animalWeight;
    }

    protected string AnimalType
    {
        get
        {
            return this.animalType;
        }
    }

    protected string AnimalName
    {
        get
        {
            return this.animalName;
        }
    }

    protected double AnimalWeight
    {
        get
        {
            return this.animalWeight;
        }
    }

    protected int FoodEaten
    {
        get
        {
            return this.foodEaten;
        }
    }

    public abstract string MakeSound();

    public virtual void Eat(Food food)
    {
        this.foodEaten += food.Quantity;
    }
}