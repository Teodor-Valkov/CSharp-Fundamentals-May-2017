public class CarFactory
{
    public static PerformanceCar CreatePerformanceCar(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
    {
        return new PerformanceCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
    }

    public static ShowCar CreateShowCar(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
    {
        return new ShowCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
    }
}